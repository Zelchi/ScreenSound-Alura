using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasEndpoints
{
    private record MusicaRequest([Required] string nome, [Required] int ArtistaId, [Required] int anoLancamento, [Required] ICollection<GeneroRequest> generos);
    private record GeneroRequest([Required] string nome, [Required] string descricao, [Required] ICollection<MusicaRequest> musicas);

    public static void MapMusicasEndpoints(this WebApplication app)
    {
        // Endpoint para pegar a lista de músicas
        app.MapGet("/musicas", ([FromServices] DAL<Musica> dal) =>
        {
            var musicas = dal.Listar();
            return Results.Ok(musicas);
        });

        // Endpoint para pegar uma música específica pelo título
        app.MapGet("/musicas/{titulo}", ([FromServices] DAL<Musica> dal, string titulo) =>
        {
            var musica = dal.RecuperarPor(m => m.Nome.ToUpper().Equals(titulo.ToUpper()));
            if (musica is null)
            {
                return Results.NotFound($"Música não encontrada.");
            }
            return Results.Ok(musica);
        });

        // Endpoint para adicionar uma nova música
        app.MapPost("/musicas", ([FromBody] MusicaRequest musicaRequest, [FromServices] DAL<Musica> dal) =>
        {
            var musica = new Musica(musicaRequest.nome)
            {
                AnoLancamento = musicaRequest.anoLancamento,
                Generos = musicaRequest.generos != null ? GeneroRequestConverter(musicaRequest.generos) : new List<Genero>()
            };
            dal.Adicionar(musica);
            return Results.Created($"/musicas/{musica.Nome}", musica);
        });

        // Endpoint para atualizar uma música existente
        app.MapPut("/musicas/{id}", ([FromServices] DAL<Musica> dal, [FromBody] Musica musicaAtualizada, string id) =>
        {
            var musica = dal.RecuperarPor(m => m.Id.ToString().Equals(id));
            if (musica is null)
            {
                return Results.NotFound("Música não encontrada.");
            }

            musica.Nome = musicaAtualizada.Nome;
            musica.Id = musicaAtualizada.Id;
            dal.Atualizar(musica);
            return Results.Ok(musica);
        });
    }

    // Método auxiliar para converter a lista de GeneroRequest em ICollection<Genero>
    private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos)
    {
        return generos.Select(a => RequestToEntity(a)).ToList();
    }

    private static Genero RequestToEntity(GeneroRequest genero)
    {
        return new Genero() { Nome = genero.nome, Descricao = genero.descricao };
    }
}