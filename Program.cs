class Program
{
    static int Menu()
    {
        int opcao;
        do
        {
            System.Console.WriteLine("Digite uma opção:\n1) Registrar entrada de um espectador.\n2) Registrar Saída de um espectador.\n3) Consultar ingressos disponíveis.\n4) Exibir Resumo.\n5) Listar espectadores presentes.\n6) Sair.");
            opcao = int.Parse(Console.ReadLine());
            if (opcao > 6 || opcao < 1)
                System.Console.WriteLine("Insira uma opção válida");
        } while (opcao != 6);

        return opcao;
    }

    static void RegistrarEntrada(string[] tipo, string[] nomeVip, string[] nomeComum, string[] nomePriori, int[] idadeVip, int[] idadeComum, int[] idadePriori, int[] numeroVip, int[] numeroComum, int[] numeroPriori, ref int contVip, ref int contComum, ref int contPriori, ref int entrada, ref int entradaVip, ref int entradaComum, ref int entradaPriori, ref string nomeUltimoEntrada, ref string tipoUltimoEntrada, ref int idadeUltimoEntrada, ref int numeroIngressoUltimoEntrada)
    {
        string fim = "nao";
        do
        {
            int idade;
            string nome;
            System.Console.WriteLine("Insira o nome do espectador");
            nome = Console.ReadLine();

            System.Console.WriteLine("Insira a idade espectador");
            idade = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Insira o tipo de ingresso do espectador (V ou C ou P)");
            tipo[entrada] = Console.ReadLine();

            switch (tipo[entrada])
            {
                case "V":
                    if (contVip < entradaVip)
                    {
                        tipo[entrada] = "VIP";
                        nomeVip[contVip] = nome;
                        idadeVip[contVip] = idade;
                        numeroVip[contVip] = entrada;
                        nomeUltimoEntrada = nome;
                        tipoUltimoEntrada = tipo[entrada];
                        idadeUltimoEntrada = idade;
                        numeroIngressoUltimoEntrada = entrada;
                        contVip++;
                        fim = "sim";
                    }
                    break;

                case "C":
                    if (contComum < entradaComum)
                    {
                        tipo[entrada] = "Comum";
                        nomeComum[contComum] = nome;
                        idadeComum[contComum] = idade;
                        numeroComum[contComum] = entrada;
                        nomeUltimoEntrada = nome;
                        tipoUltimoEntrada = tipo[entrada];
                        idadeUltimoEntrada = idade;
                        numeroIngressoUltimoEntrada = entrada;
                        contComum++;
                        fim = "sim";
                    }
                    break;

                case "P":
                    if (contPriori < entradaPriori)
                    {
                        tipo[entrada] = "Prioritário";
                        nomePriori[contPriori] = nome;
                        idadePriori[contPriori] = idade;
                        numeroPriori[contPriori] = entrada;
                        nomeUltimoEntrada = nome;
                        tipoUltimoEntrada = tipo[entrada];
                        idadeUltimoEntrada = idade;
                        numeroIngressoUltimoEntrada = entrada;
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

    static void RegistrarSaida(string[] tipo, string[] nomeVip, string[] nomeComum, string[] nomePriori,
                           int[] idadeVip, int[] idadeComum, int[] idadePriori,
                           int[] numeroVip, int[] numeroComum, int[] numeroPriori,
                           ref int contVip, ref int contComum, ref int contPriori)
    {
        System.Console.WriteLine("Digite o número do ingresso do espectador que deseja sair:");
        int numero = int.Parse(Console.ReadLine());

        if (numero < 0 || numero >= tipo.Length || tipo[numero] == null)
        {
            System.Console.WriteLine("Número de ingresso inválido.");
            return;
        }

        string categoria = tipo[numero];

        switch (categoria)
        {
            case "VIP":
                for (int i = 0; i < contVip; i++)
                {
                    if (numeroVip[i] == numero)
                    {
                        for (int j = i; j < contVip - 1; j++)
                        {
                            nomeVip[j] = nomeVip[j + 1];
                            idadeVip[j] = idadeVip[j + 1];
                            numeroVip[j] = numeroVip[j + 1];
                        }
                        contVip--;
                        tipo[numero] = null;
                        System.Console.WriteLine("Saída registrada com sucesso.");
                        return;
                    }
                }
                break;

            case "Comum":
                for (int i = 0; i < contComum; i++)
                {
                    if (numeroComum[i] == numero)
                    {
                        for (int j = i; j < contComum - 1; j++)
                        {
                            nomeComum[j] = nomeComum[j + 1];
                            idadeComum[j] = idadeComum[j + 1];
                            numeroComum[j] = numeroComum[j + 1];
                        }
                        contComum--;
                        tipo[numero] = null;
                        System.Console.WriteLine("Saída registrada com sucesso.");
                        return;
                    }
                }
                break;

            case "Prioritário":
                for (int i = 0; i < contPriori; i++)
                {
                    if (numeroPriori[i] == numero)
                    {
                        for (int j = i; j < contPriori - 1; j++)
                        {
                            nomePriori[j] = nomePriori[j + 1];
                            idadePriori[j] = idadePriori[j + 1];
                            numeroPriori[j] = numeroPriori[j + 1];
                        }
                        contPriori--;
                        tipo[numero] = null;
                        System.Console.WriteLine("Saída registrada com sucesso.");
                        return;
                    }
                }
                break;
        }

        System.Console.WriteLine("Espectador não encontrado ou já saiu.");
    }

    static void ConsultarIngresso(int entradaVip, int entradaComum, int entradaPriori, int contVip, int contComum, int contPriori)
    {
        System.Console.WriteLine("O número de ingressos VIPs disponiveis é " + (entradaVip - contVip));
        System.Console.WriteLine("O número de ingressos comuns disponiveis é " + (entradaComum - contComum));
        System.Console.WriteLine("O número de ingressos Prioritários disponiveis é " + (entradaPriori - contPriori));
    }

    static void ExibirResumo(int contVip, int contComum, int contPriori, int entradaVip, int entradaComum, int entradaPriori)
    {
        int totalPresentes = contVip + contComum + contPriori;

        System.Console.WriteLine("\n===== RESUMO DO EVENTO =====");
        System.Console.WriteLine("Número total de espectadores presentes: " + totalPresentes);

        if (totalPresentes > 0)
        {
            int percVip = (contVip * 100) / totalPresentes;
            int percComum = (contComum * 100) / totalPresentes;
            int percPriori = (contPriori * 100) / totalPresentes;

            System.Console.WriteLine("\nQuantidade e percentual por categoria:");
            System.Console.WriteLine("VIP: " + contVip + " (" + percVip + "%)");
            System.Console.WriteLine("Comum: " + contComum + " (" + percComum + "%)");
            System.Console.WriteLine("Prioritário: " + contPriori + " (" + percPriori + "%)");
        }
        else
        {
            System.Console.WriteLine("Nenhum espectador presente no momento.");
        }

        System.Console.WriteLine("\nIngressos disponíveis por categoria:");
        System.Console.WriteLine("VIP: " + (entradaVip - contVip));
        System.Console.WriteLine("Comum: " + (entradaComum - contComum));
        System.Console.WriteLine("Prioritário: " + (entradaPriori - contPriori));
    }

    static void ExibirLista(string[] nomeVip, string[] nomeComum, string[] nomePriori, int[] idadeVip, int[] idadeComum, int[] idadePriori, int[] numeroVip, int[] numeroComum, int[] numeroPriori)
    {
        System.Console.WriteLine("-- VIPS --");
        for (int i = 0; i < nomeVip.Length; i++)
        {
            System.Console.WriteLine("Espectador: " + nomeVip[i] + " | idade: " + idadeVip[i] + " | n° Ingresso: " + numeroVip[i]);
        }
        System.Console.WriteLine("-- Comuns --");

        for (int i = 0; i < nomeComum.Length; i++)
        {
            System.Console.WriteLine("Espectador: " + nomeComum[i] + " | idade: " + idadeComum[i] + " | n° Ingresso: " + numeroComum[i]);
        }
        System.Console.WriteLine("-- Prioritários --");

        for (int i = 0; i < nomePriori.Length; i++)
        {
            System.Console.WriteLine("Espectador: " + nomePriori[i] + " | idade: " + idadePriori[i] + " | n° Ingresso: " + numeroPriori[i]);
        }
    }

    static void Main()
    {
        /* Variáveis e aberturas para Arquivos */
        Stream entradaDados = File.Open("show_in.txt", FileMode.Open);
        StreamReader leitor = new StreamReader(entradaDados);
        Stream saida = File.Open("show_out.txt", FileMode.Create);
        StreamWriter escritor = new StreamWriter(saida);

        /* Recebe a quantidade de ingresso pelo arquivo */
        int entradaVip = int.Parse(leitor.ReadLine());
        int entradaComum = int.Parse(leitor.ReadLine());
        int entradaPriori = int.Parse(leitor.ReadLine());

        /* Total de ingressos */
        int totalIng = entradaVip + entradaPriori + entradaComum;

        /* Ingressos Vips */
        string[] nomeVip = new string[entradaVip];
        int[] idadeVip = new int[entradaVip];
        int[] numeroVip = new int[entradaVip];

        /* Ingressos Comuns */
        string[] nomeComum = new string[entradaComum];
        int[] idadeComum = new int[entradaComum];
        int[] numeroComum = new int[entradaComum];

        /* Ingressos Prioritários */
        string[] nomePriori = new string[entradaPriori];
        int[] idadePriori = new int[entradaPriori];
        int[] numeroPriori = new int[entradaPriori];

        /* Vetor com os tipos de ingressos de todos | O número do ingresso é o índice do tipo para achar o ingresso */
        string[] tipo = new string[totalIng];


        /* Opcao para o menu */
        /* Entrada para quantas pessoas entraram no total */
        /* Conts para quantas pessoas entraram em cada categoria*/
        /* UltimoEntrada para as informações do último espectador que entrou */
        int opcao, entrada = 0, contVip = 0, contComum = 0, contPriori = 0, idadeUltimoEntrada = 0, numeroIngressoUltimoEntrada = 0;
        string cidade, nomeUltimoEntrada = "", tipoUltimoEntrada = "";

        /* Pega o nome da cidade pelo arquivo */
        cidade = leitor.ReadLine();

        do
        {
            opcao = Menu();
            switch (opcao)
            {
                case 1:
                    RegistrarEntrada(tipo, nomeVip, nomeComum, nomePriori, idadeVip, idadeComum, idadePriori, numeroVip, numeroComum, numeroPriori, ref contVip, ref contComum, ref contPriori, ref entrada, ref entradaVip, ref entradaComum, ref entradaPriori, ref nomeUltimoEntrada, ref tipoUltimoEntrada, ref idadeUltimoEntrada, ref numeroIngressoUltimoEntrada);
                    entrada++;
                    break;

                case 2:
                    RegistrarSaida(tipo, nomeVip, nomeComum, nomePriori, idadeVip, idadeComum, idadePriori, numeroVip, numeroComum, numeroPriori, ref contVip, ref contComum, ref contPriori);
                    break;

                case 3:
                    ConsultarIngresso(entradaVip, entradaComum, entradaPriori, contVip, contComum, contPriori);
                    break;

                case 4:
                    ExibirResumo(contVip, contComum, contPriori, entradaVip, entradaComum, entradaPriori);
                    break;

                case 5:
                    ExibirLista(nomeVip, nomeComum, nomePriori, idadeVip, idadeComum, idadePriori, numeroVip, numeroComum, numeroPriori);
                    break;

                case 6:
                    System.Console.WriteLine("Encerrando o programa... Obrigado por utilizar o sistema.");
                    break;

                default:
                    System.Console.WriteLine("Insira uma opção válida");
                    break;
            }
        } while (opcao != 6);


        /* Gravar no arquivo */
        escritor.WriteLine("Cidade do evento: " + cidade);
        escritor.WriteLine("Número de espectadores: " + entrada);
        escritor.WriteLine("VIPS: " + contVip + " espectadores (" + (contVip * 100) / entradaVip + "% do total disponível) ");
        escritor.WriteLine("Comuns: " + contComum + " espectadores (" + (contComum * 100) / entradaComum + "% do total disponível) ");
        escritor.WriteLine("Prioritários: " + contPriori + " espectadores (" + (contPriori * 100) / entradaPriori + "% do total disponível) ");

        /* Fechar variáveis de gravação e leitura */
        leitor.Close();
        entradaDados.Close();
        saida.Close();
        escritor.Close();
    }
}
