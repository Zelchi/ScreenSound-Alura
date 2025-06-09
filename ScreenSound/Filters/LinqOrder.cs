using ScreenSound.Models;

namespace ScreenSound.Filters;
internal class LinqOrder
{
    public static void ExibirListaDeArtistasOrdenados(List<Musica> musicas)
    {
        var artistasOrdenados = musicas.OrderBy(musicas => musicas.Banda).Select(musica => musica.Banda).Distinct().ToList();
        foreach (var banda in artistasOrdenados)
        {
            Console.WriteLine($"Lista de bandas ordenadas: {banda}");
        }
    }
}