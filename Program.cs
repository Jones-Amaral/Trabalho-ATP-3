/* Uma empresa que realiza eventos em cidades contratou sua empresa para desenvolver um sistema para gerenciar os ingressos do evento. 
Os eventos possuem ingressos limitados, divididos em três categorias: VIP, Prioritários e Comuns. 
Cada categoria tem um número máximo de ingressos disponíveis. 
Para controlar os dados dos espectadores presentes no evento, utilize vetores para armazenar as informações de cada espectador (nome, idade, número do ingresso e tipo de ingresso), sendo um vetor para cada categoria de ingresso.
Desenvolva um programa em C# para a gestão do evento, apresentando ao usuário um menu com as seguintes opções:

1. Registrar entrada de um espectador: solicitar nome, idade, número do ingresso e tipo de ingresso. 
Os dados devem ser armazenados no vetor correspondente à categoria do ingresso, se houver disponibilidade.

2. Registrar saída de um espectador: solicitar o número do ingresso e tipo de ingresso. 
O espectador deve ser removido do vetor correspondente e o ingresso liberado novamente para uso.

3. Consultar ingressos disponíveis: 
exibir quantos ingressos ainda estão disponíveis em cada uma das categorias, considerando a capacidade máxima e o número de entradas registradas nos vetores.

4. Exibir resumo do evento: mostrar:
o Número total de espectadores presentes;
o Quantidade e percentual de espectadores por categoria;
o Ingressos disponíveis por categoria;

5. Listar todos os espectadores presentes: 
exibir os dados (nome, idade, número do ingresso e tipo de ingresso) de todos os espectadores registrados nos vetores, organizados por categoria.

6. Sair */using System.Collections.Specialized;

class Program
{
    static int Menu()
    {
        int opcao;
        do
        {
            System.Console.WriteLine("Digite uma opção:\n1) Registrar saída de um espectador.\n2) Registrar Saída de um espectador.\n3) Consultar ingressos disponíveis.\n4) Exibir Resumo.\n5) Listar espectadores presentes.\n6) Sair.");
            opcao = int.Parse(Console.ReadLine());
            if (opcao > 6 || opcao < 1)
                System.Console.WriteLine("Insira uma opção válida");
        } while (opcao != 6); // Isso manterá o menu até digitar 6 (talvez você queira != 0 em vez disso)

        return opcao;
    }

    static void RegistrarEntrada(string[] nome, int[] idade, int[] numeroIngresso, string[] tipo, string[] ingVip, string[] ingComum, string[] ingPriori, int contVip, int contComum, int contPriori, int entrada)
    {
        string fim = "nao";
        do
        {
            System.Console.WriteLine("Insira o nome do espectador");
            nome[entrada] = Console.ReadLine();

            System.Console.WriteLine("Insira a idade espectador");
            idade[entrada] = int.Parse(Console.ReadLine());

            numeroIngresso[entrada] = entrada;

            System.Console.WriteLine("Insira o tipo de ingresso do espectador");
            tipo[entrada] = Console.ReadLine();

            switch (tipo[entrada])
            {
                case "vip":
                    if (contVip < ingVip.Length)
                    {
                        tipo[entrada] = "VIP";
                        ingVip[contVip] = nome[entrada];
                        contVip++;
                    }
                    fim = "sim";
                    break;

                case "comum":
                    if (contComum < ingComum.Length)
                    {
                        tipo[entrada] = "Comum";
                        ingComum[entrada] = nome[entrada];
                        contComum++;
                        fim = "sim";
                    }
                    break;

                case "prioritario":
                    if (contPriori < ingPriori.Length)
                    {
                        tipo[entrada] = "Prioritário";
                        ingPriori[entrada] = nome[entrada];
                        contPriori++;
                        fim = "sim";
                    }
                    break;

                default:
                    System.Console.WriteLine("Tipo inválido");
                    fim = "nao";
                    break;
            }

        } while (fim != "sim");
    }

    static void RegistrarSaida()
    {

    }

    static void ConsultarIngresso(int entradaVip, int entradaComum, int entradaPriori, int contVip, int contComum, int contPriori)
    {
        System.Console.WriteLine("O número de ingressos VIPs disponiveis é " + (entradaVip - contVip));
        System.Console.WriteLine("O número de ingressos comuns disponiveis é " + (entradaComum - contComum));
        System.Console.WriteLine("O número de ingressos Prioritários disponiveis é " + (entradaPriori - contPriori));
    }

    static void ExibirResumo()
    {

    }
    static void ExibirLista()
    {

    }

    static void Main()
    {
        Stream entradaDados = File.Open("show_in.txt", FileMode.Open);
        StreamReader leitor = new StreamReader(entradaDados);
        Stream saida = File.Open("show_out.txt", FileMode.Create);
        StreamWriter escritor = new StreamWriter(saida);

        int entradaVip = int.Parse(leitor.ReadLine());
        int entradaComum = int.Parse(leitor.ReadLine());
        int entradaPriori = int.Parse(leitor.ReadLine());

        int totalIng = entradaVip + entradaPriori + entradaComum;
        string[] nomeVip = new string[entradaVip];
        string[] nomeComum = new string[entradaComum];
        string[] nomePriori = new string[entradaPriori];

        int[] idadeVip = new int[entradaVip];
        int[] idadeComum = new int[entradaComum];
        int[] idadePriori = new int[entradaPriori];

        int[] numeroVip = new int[entradaVip];
        int[] numeroComum = new int[entradaComum];
        int[] numeroPriori = new int[entradaPriori];

        string[] ingVip = new string[entradaVip]; // [Quantidade máxima de ingressos de cada tipo]
        string[] ingComum = new string[entradaComum]; // [Quantidade máxima de ingressos de cada tipo]
        string[] ingPriori = new string[entradaPriori]; // [Quantidade máxima de ingressos de cada tipo]
        string[] tipo = new string[totalIng];

        int opcao, entrada = 0, contIngresso = 0, contVip = 0, contComum = 0, contPriori = 0, idadeUltimo, numeroIngressoUltimo;
        string cidade, nomeUltimo, tipoUltimo;

        cidade = leitor.ReadLine();

        System.Console.WriteLine(entradaComum + ", " + entradaPriori + ", " + entradaVip);
        opcao = Menu();

        switch (opcao)
        {
            case 1:
                RegistrarEntrada(nome, idade, numeroIngresso, tipo, ingVip, ingComum, ingPriori, contVip, contComum, contPriori, entrada);
                contIngresso++;
                entrada++;
                break;

            case 2:

                break;

            case 3:
                ConsultarIngresso(entradaVip, entradaComum, entradaPriori, contVip, contComum, contPriori);
                break;

            case 4:

                break;

            case 5:
                ExibirResumo();
                break;

            case 6:

                break;

            default:
                System.Console.WriteLine("Insira uma opção válida");
                break;
        }


        escritor.WriteLine("Cidade do evento: " + cidade);
        escritor.WriteLine("Número de espectadores: " + entrada);
        escritor.WriteLine("VIPS: " + contVip + " espectadores (" + (contVip * 100) / entradaVip + "% do total disponível) ");
        escritor.WriteLine("Comuns: " + contComum + " espectadores (" + (contComum * 100) / entradaComum + "% do total disponível) ");
        escritor.WriteLine("Prioritários: " + contPriori + " espectadores (" + (contPriori * 100) / entradaPriori + "% do total disponível) ");

        leitor.Close();
        entradaDados.Close();
        saida.Close();
        escritor.Close();
    }
}
