using System.Numerics;
using System.Text.Json;

namespace ScreenSound.Models;

internal class MusicasFavoritas
{
    string Nome;
    List<Musica> ListaDeMusicasFavoritas;

    public MusicasFavoritas(string nome)
    {
        Nome = nome;
        ListaDeMusicasFavoritas = new List<Musica>();
    }

    public void AdicionarMusica(params Musica[] musicas) // <- varArgs permite passar múltiplos parâmetros do tipo Musica
    {
        int tamanho = musicas.Length;
        Console.WriteLine(tamanho);
        ListaDeMusicasFavoritas.AddRange(musicas);
    }

    // Sobrecarga do método Somar para aceitar diferentes tipos de parâmetros
    public void Somar(BigInteger a, int b)
    {
        BigInteger resultado = a + b;
        Console.WriteLine($"Resultado da soma: {resultado}");
    }

    public void Somar(int a, BigInteger b)
    {
        BigInteger resultado = a + b;
        Console.WriteLine($"Resultado da soma: {resultado}");
    }

    // Sobrecarga do método AdicionarMusica para aceitar uma lista de músicas
    public void AdicionarMusica(List<Musica> musicas) // <- varArgs permite passar múltiplos parâmetros do tipo Musica
    {
        this.AdicionarMusica(musicas.ToArray());
    }

    public void ExibirMusicasFavoritas()
    {
        Console.WriteLine($"Essas são as músicas favoritas de {Nome}:");
        foreach (var musica in ListaDeMusicasFavoritas)
        {
            Console.WriteLine($"- {musica.Nome} - {musica.Banda}");
        }
        Console.WriteLine("-------");
    }

    public void GerarArquivo()
    {
        try
        {
            string json = JsonSerializer.Serialize(new
            {
                nome = Nome,
                musicas = ListaDeMusicasFavoritas
            });
            string nomeDoArquivo = $"Musicas-favoritas-{Nome}.json";

            File.WriteAllText(nomeDoArquivo, json);
            Console.WriteLine("O arquivo Json foi criado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}