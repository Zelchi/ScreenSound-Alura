using System.Text.Json.Serialization;

namespace ScreenSound.Models;

internal class Musica
{
    public Musica(string banda, string nome, int duracao, string genero, string ano, int key)
    {
        Banda = banda;
        Nome = nome;
        Duracao = duracao;
        Genero = genero;
        Ano = ano;
        Tonalidade = key;
    }

    [JsonPropertyName("artist")]
    public string Banda { get; set; }

    [JsonPropertyName("song")]
    public string Nome { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }

    [JsonPropertyName("genre")]
    public string Genero { get; set; }

    [JsonPropertyName("year")]
    public string Ano { get; set; }

    [JsonPropertyName("key")]
    public int Tonalidade { get; set; }

    private string[] Tonalidades = {
        "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"
    };

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Banda}");
        Console.WriteLine($"Duração: {Duracao / 1000}");
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine($"Ano: {Ano}");
        Console.WriteLine($"Tonalidade: {Tonalidades[Tonalidade]}");
    }
}