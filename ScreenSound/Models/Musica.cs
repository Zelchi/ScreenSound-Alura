using System;
using System.Text.Json.Serialization;

namespace ScreenSound.Models;

internal class Musica
{
    Musica()
    {
        Banda = string.Empty;
        Nome = string.Empty;
        Duracao = string.Empty;
        Genero = string.Empty;
        Ano = string.Empty;
    }

    [JsonPropertyName("artist")]
    public string Banda { get; set; }

    [JsonPropertyName("song")]
    public string Nome { get; set; }

    [JsonPropertyName("duration")]
    public string Duracao { get; set; }

    [JsonPropertyName("genre")]
    public string Genero { get; set; }

    [JsonPropertyName("year")]
    public string Ano { get; set; }

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Banda}");
        Console.WriteLine($"Duração: {Duracao}");
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine($"Ano: {Ano}");
    }
}