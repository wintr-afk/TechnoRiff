//Screen Sound, um app de musicas.
string mensagemDeBoasVindas = "\nBoas vindas ao programa Techno Riff!"; //C# é uma linguagem altamente tipada, ou seja, é necessário declarar o tipo da variável.
//List<string> listaDasBandas = new List<string>{"System of a Down", "Slipknot", "SAMURAI", "Linkin Park"};//List é uma lista de strings, ou seja, uma coleção de strings

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();//Dictionary é um dicionário que tem uma chave do tipo string e um valor do tipo List<int>
bandasRegistradas.Add("System of a Down", new List<int>{10, 9, 9});//adiciona a banda ao dicionário com uma lista de avaliações
bandasRegistradas.Add("Slipknot", new List<int>{9, 8, 7});
bandasRegistradas.Add("Foo Fighters", new List<int>{8, 7, 6});
bandasRegistradas.Add("Linkin Park", new List<int>{7, 8, 10});

void ExibirMenu()//void é um tipo de função que não da retorno
{
    Console.WriteLine(@"
    ████████╗███████╗░█████╗░██╗░░██╗███╗░░██╗░█████╗░  ██████╗░██╗███████╗███████╗
    ╚══██╔══╝██╔════╝██╔══██╗██║░░██║████╗░██║██╔══██╗  ██╔══██╗██║██╔════╝██╔════╝
    ░░░██║░░░█████╗░░██║░░╚═╝███████║██╔██╗██║██║░░██║  ██████╔╝██║█████╗░░█████╗░░
    ░░░██║░░░██╔══╝░░██║░░██╗██╔══██║██║╚████║██║░░██║  ██╔══██╗██║██╔══╝░░██╔══╝░░
    ░░░██║░░░███████╗╚█████╔╝██║░░██║██║░╚███║╚█████╔╝  ██║░░██║██║██║░░░░░██║░░░░░
    ░░░╚═╝░░░╚══════╝░╚════╝░╚═╝░░╚═╝╚═╝░░╚══╝░╚════╝░  ╚═╝░░╚═╝╚═╝╚═╝░░░░░╚═╝░░░░░");//@ serve para escrever o texto no código exatamente como ele é
    Console.WriteLine(mensagemDeBoasVindas);
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a opção desejada: ");//Escreve no console sem pular linha
    string opcaoEscolhida = Console.ReadLine()!;//! serve pra dizer que a variável não é nula
    int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);//converte a string em inteiro
    switch(opcaoEscolhidaNum)//escolher entre uma das opções setadas
    {
        case 1: RegistrarBanda();
            break;//break serve para sair do switch depois de executar a opção escolhida
        case 2: MostrarBandas();
            break;
        case 3: AvaliarBanda();
            break;
        case 4: ExibirMediaBanda();
            break;
        case -1: Console.WriteLine("Tchau tchau! ;)");
                Thread.Sleep(1500);
                Console.Clear();
            break;
        default: Console.WriteLine("Opção inválida, tente novamente.");
                Thread.Sleep(1500);
                Console.Clear();
                ExibirMenu();
            break;
    }
}

void RegistrarBanda()//registrar uma banda ao dicionario
{
    Console.Clear();//limpa o console
    ExibirTituloPagina("Bem-vindo ao registro de bandas!");
    Console.Write("Digite o nome da banda que deseja adicionar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());//adiciona a banda ao dicionário com uma lista vazia de avaliações
    Console.WriteLine($"A banda {nomeDaBanda} adicionada com sucesso!");//$ serve pra escrever a string no meio da mensagem (interpolação de string)
    Console.WriteLine("\nDigite 1 para continuar");
    Console.WriteLine("Digite 2 para voltar ao menu");
    Console.Write("\nSelecione uma oção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);
    switch(opcaoEscolhidaNum)
    {
        case 1: RegistrarBanda();
            break;
        case 2: Console.WriteLine("Voltando ao menu...");
                Thread.Sleep(1500);//pausa o programa pelo tempo determinado em milissegundos
                Console.Clear();
                ExibirMenu();
            break;
        default: Console.WriteLine("Opção não encontrada, voltando ao menu...");
                Thread.Sleep(1500);//pausa o programa pelo tempo determinado em milissegundos
                Console.Clear();
                ExibirMenu();
            break;
    }
    
}

void MostrarBandas()//mostrar as bandas registradas no dicionário
{
    Console.Clear();
    ExibirTituloPagina("Bem-vindo à lista de bandas adicionadas!");
    //for (int i = 0; i < listaDasBandas.Count; i++){
    //    Console.WriteLine($"{i+1} - {listaDasBandas[i]}");}//imprime o índice e o nome da banda na lista
    foreach (string banda in bandasRegistradas.Keys)//foreach percorre a lista de bandas e imprime cada banda na tela
    {//Keys é o valor da chave do dicionário, ou seja, o nome da banda
        Console.WriteLine($"- {banda}");
    }
    Console.Write("\nDigite qualquer tecla para voltar ao menu");
    Console.ReadKey();//espera o usuário digitar uma tecla para continuar
    Console.Clear();
    ExibirMenu();

}

void AvaliarBanda()//avaliar uma banda registrada no dicionário
{
    //digitar qual banda deseja avaliar
    //verificar se a banda existe no dicionário
    //se existir, solicitar a nota de 0 a 10. Senão, rodar o avaliarbanda() novamente
    //adicionar a nota na lista de avaliações da banda no dicionário

    Console.Clear();
    ExibirTituloPagina("Bem-vindo à avaliação de bandas!");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"\nQual a nota que a banda {nomeDaBanda} merece? (0 a 10): ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);//adiciona a nota na lista de avaliações da banda no dicionário
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}!");
        Console.WriteLine("\nDigite 1 para avaliar outra banda");
        Console.WriteLine("Digite 2 para voltar ao menu");
        Console.Write("\nSelecione uma oção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);
        switch (opcaoEscolhidaNum)
        {
            case 1: AvaliarBanda();
                break;
            case 2: Console.WriteLine("Voltando ao menu...");
                    Thread.Sleep(1500);
                    Console.Clear();
                    ExibirMenu();
                break;
            default: Console.WriteLine("Opção não encontrada, voltando ao menu...");
                    Thread.Sleep(1500);
                    Console.Clear();
                    ExibirMenu();
                break;
        }


    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada nos registros, tente novamente.");
        Thread.Sleep(1500);
        AvaliarBanda();
    }
    
}

void ExibirMediaBanda()//exibe a média da banda escolhida
{
    //digitar qual banda deseja ver a média >> verificar se existe
    //se existe, calcular média das notas e ecibir na tela. Senão, rodar o ExibirMediaBanda() novamente
    //média = soma das notas / quantidade de notas
    //exibir retorno ao menu
    Console.Clear();
    ExibirTituloPagina("Bem-vindo à exibição da média de bandas!");
    Console.Write("Digite o nome da banda que deseja ver a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"\nCalculando a média da banda {nomeDaBanda}...");
        Thread.Sleep(1500);
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"A média da banda {nomeDaBanda} é {notasDaBanda.Average():F2}");//Avarege() é uma função em C# que calcula a média de uma lista de números
        Console.WriteLine("\nDigite 1 para calcular a média de outra banda");
        Console.WriteLine("Digite 2 para voltar ao menu");
        Console.Write("\nSelecione uma oção: ");
        string opcaoEscolhida = Console.ReadLine()!;
        int opcaoEscolhidaNum = int.Parse(opcaoEscolhida);
        switch (opcaoEscolhidaNum)
        {
            case 1: ExibirMediaBanda();
                break;
            case 2: Console.WriteLine("Voltando ao menu...");
                    Thread.Sleep(1500);
                    Console.Clear();
                    ExibirMenu();
                break;
            default: Console.WriteLine("Opção não encontrada, voltando ao menu...");
                    Thread.Sleep(1500);
                    Console.Clear();
                    ExibirMenu();
                break;
        }
    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada nos registros, tente novamente.");
        Thread.Sleep(1500);
        ExibirMediaBanda();
    }

}

void ExibirTituloPagina(string titulo)//faz o efeito de traçejado em cima e em baixo do título da página
{
    int quantidadeDeLetras = titulo.Length;
    string tracos = string.Empty.PadLeft(quantidadeDeLetras, '-');
    Console.WriteLine(tracos);
    Console.WriteLine(titulo);
    Console.WriteLine(tracos + "\n");
}

ExibirMenu();