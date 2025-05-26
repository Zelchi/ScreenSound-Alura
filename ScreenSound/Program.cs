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

Dictionary<int, Menu> opcoes = new()
{
    { 1, new RegistrarBanda() },
    { 2, new RegistrarAlbum() },
    { 3, new MostrarBandasRegistradas() },
    { 4, new AvaliarBanda() },
    { 5, new AvaliarAlbum() },
    { 6, new ExibirDetalhes() },
};

void ExibirOpcoesDoMenu()
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
    int opcaoEscolhidaInt = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaInt))
    {
        Menu menuEscolhido = opcoes[opcaoEscolhidaInt];
        menuEscolhido.Executar(bandasRegistradas);
        ExibirOpcoesDoMenu();
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
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();