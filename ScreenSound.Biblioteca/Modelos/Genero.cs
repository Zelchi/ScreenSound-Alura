using System.Text.Json.Serialization;

namespace ScreenSound.Modelos;

public class Genero
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    [JsonIgnore]
    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Descrição: {Descricao}");
    }

    public override string ToString()
    {
        return $"Id: {Id}\nNome: {Nome}\nDescrição: {Descricao}";
    }
}