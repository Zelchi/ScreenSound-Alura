using ScreenSound.Models;
using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using HttpClient client = new();

        try
        {
            string res = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
            List<Musica> musicas = JsonSerializer.Deserialize<List<Musica>>(res)!;
            Console.WriteLine($"Foram carregadas {musicas.Count} músicas");
            Console.WriteLine($"Primeira música: {musicas[0].Nome}");
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