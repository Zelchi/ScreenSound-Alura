using ScreenSound.API.Requests;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints;

public static class ArtistasEndpoints
{
    public static void MapArtistasEndpoints(this WebApplication app)
    {
        // Endpoint para pegar a lista de artistas
        app.MapGet("/artistas", ([FromServices] DAL<Artista> dal) =>
        {
            var artistas = dal.Listar();
            return Results.Ok(artistas);
        });

        // Endpoint para pegar um artista específico pelo nome
        app.MapGet("/artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (artista is null)
            {
                return Results.NotFound($"Artista não encontrado.");
            }
            return Results.Ok(artista);
        });

        // Endpoint para adicionar um novo artista
        app.MapPost("/artistas", ([FromBody] ArtistaRequest artistaRequest, [FromServices] DAL<Artista> dal) =>
        {
            var artista = new Artista(artistaRequest.nome, artistaRequest.bio);
            dal.Adicionar(artista);
            return Results.Created($"/artistas/{artista.Nome}", artista);
        });

        // Endpoint para atualizar um artista existente
        app.MapPut("/artistas/{id}", ([FromServices] DAL<Artista> dal, [FromBody] Artista artistaAtualizado, string id) =>
        {
            var artista = dal.RecuperarPor(a => a.Id.ToString().Equals(id));
            if (artista is null)
            {
                return Results.NotFound("Artista não encontrado.");
            }

            artista.Nome = artistaAtualizado.Nome;
            dal.Atualizar(artista);
            return Results.Ok(artista);
        });
    }
}