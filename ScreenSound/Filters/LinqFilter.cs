using ScreenSound.Models;
namespace ScreenSound.Filters;

internal class LinqFilter
{
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        var todosOsGenerosMusicais = musicas.Select(generos => generos.Genero).Distinct().ToList();

        foreach (var genero in todosOsGenerosMusicais)
        {
            Console.WriteLine($"- {genero}");
        }
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistasPorGeneroMusical = musicas.Where(musica => musica.Genero.Contains(genero)).Select(musica => musica.Banda).Distinct().ToList();
        
        if (artistasPorGeneroMusical.Count == 0)
        {
            Console.WriteLine($"Nenhum artista encontrado para o gênero: {genero}");
            return;
        }

        foreach (var banda in artistasPorGeneroMusical)
        {
            Console.WriteLine($"Artistas do gênero {genero}: {banda}");
        }
    }

    public static void FiltrarMusicasDeUmArtista(List<Musica> musicas, string nomeDoArtista)
    {
        var musicasDoArtista = musicas.Where(musica => musica.Banda.Equals(nomeDoArtista)).ToList();
        foreach (var musica in musicasDoArtista)
        {
            Console.WriteLine($"- {musica.Nome}");
        }
    }

    public static void FiltrarElementosUnicos(List<Musica> musicas)
    {
        var musicasElementosUnicos = musicas.Distinct().ToList();
        foreach (var musica in musicasElementosUnicos)
        {
            Console.WriteLine(musica.Banda.ToString());
        }
    }
}
