using ScreenSound.Models;
using ScreenSound.Menus;

Banda ira = new("Ira!");
ira.AdicionarNota(new Avaliacao(10));
ira.AdicionarNota(new Avaliacao(8));
ira.AdicionarNota(new Avaliacao(8));

Banda beatles = new("The Beatles");
beatles.AdicionarNota(new Avaliacao(10));
beatles.AdicionarNota(new Avaliacao(8));
beatles.AdicionarNota(new Avaliacao(10));

Dictionary<string, Banda> bandasRegistradas = new()
{
    { ira.Nome, ira },
    { beatles.Nome, beatles }
};

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    if (int.TryParse(opcaoEscolhida, out int opcaoEscolhidaNumerica))
    {
        switch (opcaoEscolhidaNumerica)
        {
            case 1:
                RegistrarBanda menu1 = new();
                menu1.Executar(bandasRegistradas);
                ExibirOpcoesDoMenu();
                break;
            case 2:
                RegistrarAlbum menu2 = new();
                menu2.Executar(bandasRegistradas);
                ExibirOpcoesDoMenu();
                break;
            case 3:
                MostrarBandasRegistradas menu3 = new();
                menu3.Executar(bandasRegistradas);
                ExibirOpcoesDoMenu();
                break;
            case 4:
                AvaliarBanda menu4 = new();
                menu4.Executar(bandasRegistradas);
                ExibirOpcoesDoMenu();
                break;
            case 5:
                ExibirDetalhes menu5 = new();
                menu5.Executar(bandasRegistradas);
                ExibirOpcoesDoMenu();
                break;
            case 0:
                Console.WriteLine("Tchau tchau :)");
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
    else
    {
        Console.WriteLine("Entrada inválida. Por favor, digite um número.");
    }
}

ExibirOpcoesDoMenu();