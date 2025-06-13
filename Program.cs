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

    static void RegistrarSaida(string[] nome, int[] idade, int[] numeroIngresso, string[] tipo, out int contVip, out int contComum, out int contPriori)
    {
        contVip = 0;
        contComum = 0;
        contPriori = 0;
    }

    static void ConsultarIngresso() { }

    static void ExibirResumo() { }

    static void Main()
    {
        string[] ingVip = new string[3]; // [Quantidade máxima de ingressos de cada tipo]
        string[] ingComum = new string[3]; // [Quantidade máxima de ingressos de cada tipo]
        string[] ingPriori = new string[3]; // [Quantidade máxima de ingressos de cada tipo] 
        int[] idade = new int[5];
        string[] nome = new string[5];
        int[] numeroIngresso = new int[5];
        string[] tipo = new string[5];
        int opcao, entrada = 0, entradaVip, entradaComum, entradaPriori, contIngresso = 0, contVip = 0, contComum = 0, contPriori = 0;
        string cidade;

        Stream entradaDados = File.Open("show_in.txt", FileMode.Open);
        StreamReader leitor = new StreamReader(entradaDados);

        cidade = leitor.ReadLine();
        entradaVip = int.Parse(leitor.ReadLine());
        entradaComum = int.Parse(leitor.ReadLine());
        entradaPriori = int.Parse(leitor.ReadLine());

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
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                System.Console.WriteLine("Insira uma opção válida");
                break;
        }

        leitor.Close();
        entradaDados.Close();
    }
}
