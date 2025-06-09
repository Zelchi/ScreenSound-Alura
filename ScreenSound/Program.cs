using ScreenSound.Models;
using System.Text.Json;

internal class Program
{
    private static async Task Main()
    {
        using HttpClient client = new();

        try
        {
            string res = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
            List<Musica> musicas = JsonSerializer.Deserialize<List<Musica>>(res)!;
            musicas[1].ExibirFichaTecnica();
            //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
            //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
            //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
            //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");

            //var musicasFavoritas1 = new MusicasFavoritas("Batata");

            //musicasFavoritas1.AdicionarMusica(
            //    musicas.GetRange(0, 10)
            //);

            //musicasFavoritas1.GerarArquivo();

            //musicasFavoritas1.ExibirMusicasFavoritas();

            //var musicasFavoritas2 = new MusicasFavoritas("Batata2");
            //musicasFavoritas2.AdicionarMusica(musicas[0]);
            //musicasFavoritas2.ExibirMusicasFavoritas();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro na requisição HTTP: {ex.Message}");
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Erro ao processar o JSON: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
        }
    }
}