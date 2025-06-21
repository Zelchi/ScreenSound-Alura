namespace ScreenSound.API.Endpoints;

using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

public static class MusicasEndpoints
{
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
        app.MapPost("/musicas", ([FromBody] Musica musica, [FromServices] DAL<Musica> dal) =>
        {
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
}