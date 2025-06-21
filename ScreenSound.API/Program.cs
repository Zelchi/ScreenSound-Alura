using ScreenSound.API.Endpoints;
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

            var app = builder.Build();

            app.MapArtistasEndpoints();
            app.MapMusicasEndpoints();

            app.Run();
        }
    }
}