using ScreenSound.API.Endpoints;
using ScreenSound.API.Scalar;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ScreenSoundContext>();
            builder.Services.AddTransient<DAL<Artista>>();
            builder.Services.AddTransient<DAL<Musica>>();
            builder.Services.AddOpenApi();

            var app = builder.Build();

            ScalarApp.Run(app);
            app.MapArtistasEndpoints();
            app.MapMusicasEndpoints();

            app.Run();
        }
    }
}