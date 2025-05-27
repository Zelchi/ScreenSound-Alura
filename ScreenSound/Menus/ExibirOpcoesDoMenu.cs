using ScreenSound.Models;
namespace ScreenSound.Menus;

internal class ExibirOpcoesDoMenu
{
    private static Dictionary<string, Banda>? bandasRegistradas;
    private static Dictionary<int, Menu>? opcoes;

    public ExibirOpcoesDoMenu()
    {
        bandasRegistradas = new Dictionary<string, Banda>();
        opcoes = new Dictionary<int, Menu>();
    }

    public static void Executar(Dictionary<int, Menu> opcoes, Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
        ExibirLogo.Executar();

        Console.WriteLine("\nDigite 1 para registrar uma banda");
        Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
        Console.WriteLine("Digite 3 para mostrar todas as bandas");
        Console.WriteLine("Digite 4 para avaliar uma banda");
        Console.WriteLine("Digite 5 para avaliar um álbum de uma banda");
        Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
        Console.WriteLine("Digite 0 para sair");

        Console.Write("\nDigite a sua opção: ");

        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaInt;

        if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaInt))
        {
            if (opcoes.ContainsKey(opcaoEscolhidaInt))
            {
                Menu menuEscolhido = opcoes[opcaoEscolhidaInt];
                menuEscolhido.Executar(bandasRegistradas);
                Executar(opcoes, bandasRegistradas);
            }
            else if (opcaoEscolhidaInt == 0)
            {
                Console.WriteLine("Saindo do programa...");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                Thread.Sleep(1000);
                Executar(opcoes, bandasRegistradas);
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida! Por favor, insira um número.");
            Thread.Sleep(1000);
            Executar(opcoes, bandasRegistradas);
        }
    }
}