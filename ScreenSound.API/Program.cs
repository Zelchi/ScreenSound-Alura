using static Microsoft.AspNetCore.Http.Results;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ScreenSound.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ScreenSoundContext>();
            builder.Services.AddTransient<DAL<Artista>>();

            WebApplication app = ConfigureApp(builder.Build());

            app.Run();
        }

        private static WebApplication ConfigureApp(WebApplication app)
        {
            // Endpoint de teste
            app.MapGet("/", () => "Hello World!");

            // Endpoint para pegar a lista de artistas
            app.MapGet("/artistas", ([FromServices] DAL<Artista> dal) =>
            {
                var artistas = dal.Listar();
                return Ok(artistas);
            });

            // Endpoint para pegar um artista específico pelo nome
            app.MapGet("/artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
            {
                var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (artista is null)
                {
                    return NotFound($"Artista não encontrado.");
                }
                return Ok(artista);
            });

            // Endpoint para adicionar um novo artista
            app.MapPost("/artistas", ([FromBody] Artista artista, [FromServices] DAL<Artista> dal) =>
            {
                dal.Adicionar(artista);
                return Created($"/artistas/{artista.Nome}", artista);
            });

            // Endpoint para atualizar um artista existente
            app.MapPut("/artistas/{id}", ([FromServices] DAL<Artista> dal, [FromBody] Artista artistaAtualizado, string id) =>
            {
                var artista = dal.RecuperarPor(a => a.Id.ToString().Equals(id));
                if (artista is null)
                {
                    return NotFound("Artista não encontrado.");
                }

                artista.Nome = artistaAtualizado.Nome;
                artista.Bio = artistaAtualizado.Bio;
                artista.FotoPerfil = artistaAtualizado.FotoPerfil;
                artista.Musicas = artistaAtualizado.Musicas;
                dal.Atualizar(artista);
                return Ok($"Artista {artista.Nome} atualizado com sucesso.");
            });

            // Endpoint para deletar um artista
            app.MapDelete("/artistas/{id}", ([FromServices] DAL<Artista> dal, string id) =>
            {
                var artista = dal.RecuperarPor(a => a.Id.ToString().Equals(id));
                if (artista is null)
                {
                    return NotFound($"Artista não encontrado.");
                }

                dal.Deletar(artista);
                return Ok($"Artista {artista.Nome} removido com sucesso.");
            });

            // Endpoint para pegar a lista de musicas
            app.MapGet("/musicas", ([FromServices] DAL<Musica> dal) =>
            {
                var musicas = dal.Listar();
                return Ok(musicas);
            });

            // Endpoint para pegar um musicas específico pelo nome
            app.MapGet("/musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
            {
                var musica = dal.RecuperarPor(m => m.Nome.ToUpper().Equals(nome.ToUpper()));
                if (musica is null)
                {
                    return NotFound($"Música não encontrada.");
                }
                return Ok(musica);
            });

            // Endpoint para adicionar uma nova musica
            app.MapPost("/musicas", ([FromBody] Musica musica, [FromServices] DAL<Musica> dal) =>
            {
                dal.Adicionar(musica);
                return Created($"/musicas/{musica.Nome}", musica);
            });

            // Endpoint para atualizar uma musica existente
            app.MapPut("/musicas/{id}", ([FromServices] DAL<Musica> dal, [FromBody] Musica musicaAtualizada, string id) =>
            {
                var musica = dal.RecuperarPor(m => m.Id.ToString().Equals(id));
                if (musica is null)
                {
                    return NotFound("Música não encontrada.");
                }

                musica.Nome = musicaAtualizada.Nome;
                musica.Artista = musicaAtualizada.Artista;
                musica.AnoLancamento = musicaAtualizada.AnoLancamento;
                dal.Atualizar(musica);
                return Ok($"Música {musica.Nome} atualizada com sucesso.");
            });

            // Endpoint para deletar uma musica
            app.MapDelete("/musicas/{id}", ([FromServices] DAL<Musica> dal, string id) =>
            {
                var musica = dal.RecuperarPor(m => m.Id.ToString().Equals(id));
                if (musica is null)
                {
                    return NotFound($"Música não encontrada.");
                }

                dal.Deletar(musica);
                return Ok($"Música {musica.Nome} removida com sucesso.");
            });

            return app;
        }
    }
}