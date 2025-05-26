namespace ScreenSound.Models;

internal class Album : IAvaliavel
{
    private static int quantidadeDeAlbums = 0; 
    private List<Musica> musicas = new List<Musica>();
    private List<Avaliacao> notas = new List<Avaliacao>();
    public Album(string nome)
    {
        Nome = nome;
        quantidadeDeAlbums++;
    }
    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    public List<Musica> Musicas => musicas;
    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }
    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}:\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal}");
    }
    public static int ContadorDeObjetos => quantidadeDeAlbums;
    public double Media
    {
        get
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(n => n.Nota);
        }
    }
    public static void Batata()
    {
        Album a1 = new Album("Barões da Pisadinha Ao Vivo");
        Album a2 = new Album("Barões da Pisadinha feat.Anitta");
        Album a3 = new Album("Barões da Pisadinha no Free Jazz Festival");

        Console.WriteLine($"Total de objetos criados: {Album.quantidadeDeAlbums}");
    }
    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota); 
    }
}