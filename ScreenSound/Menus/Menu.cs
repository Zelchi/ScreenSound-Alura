using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class Menu
{
    public static void ExibirTituloDaOpcao(string titulo)
    {
        Console.Clear();
        int quantidadeLetras = titulo.Length;
        string caracteres = string.Empty.PadLeft(quantidadeLetras, '*');
        Console.WriteLine(caracteres);
        Console.WriteLine(titulo);
        Console.WriteLine(caracteres);
    }

    public virtual void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();

    }
}