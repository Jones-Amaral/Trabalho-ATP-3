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
        } while (opcao < 1 || opcao > 6);

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
            tipo[entrada] = Console.ReadLine().Trim().ToUpper();

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

    static void RegistrarSaida(string[] tipo, string[] nomeVip, string[] nomeComum, string[] nomePriori, int[] idadeVip, int[] idadeComum, int[] idadePriori, int[] numeroVip, int[] numeroComum, int[] numeroPriori, ref int contVip, ref int contComum, ref int contPriori, ref string nomeUltimoSaida, ref string tipoUltimoSaida, ref int idadeUltimoSaida, ref int numeroIngressoUltimoSaida)
    {
        Console.Write("Digite o tipo de ingresso do espectador (VIP, Comum ou Prioritário): ");
        string tipoIngresso = Console.ReadLine();

        Console.Write("Digite o número do ingresso do espectador que deseja sair: ");
        if (!int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine("Número do ingresso inválido.");
            return;
        }

        // Verificar se o número está dentro dos limites do vetor tipo
        if (numero < 0 || numero >= tipo.Length)
        {
            Console.WriteLine("Número do ingresso inválido.");
            return;
        }

        // Verificar se o ingresso está realmente ocupado
        if (string.IsNullOrEmpty(tipo[numero]))
        {
            Console.WriteLine("Número do ingresso não está atribuído a nenhum espectador.");
            return;
        }

        // Padronizar o tipo armazenado
        string tipoArmazenado = tipo[numero].ToUpper();

        // Verifica se o tipo informado bate com o tipo armazenado
        if (tipoIngresso != tipoArmazenado.ToUpper())
        {
            Console.WriteLine("O tipo informado não corresponde ao número do ingresso.");
            return;
        }

        // Remover espectador da categoria correta
        switch (tipoArmazenado)
        {
            case "VIP":
                for (int i = 0; i < contVip; i++)
                {
                    if (numeroVip[i] == numero)
                    {
                        // Salvar dados do último que saiu
                        nomeUltimoSaida = nomeVip[i];
                        tipoUltimoSaida = "VIP";
                        idadeUltimoSaida = idadeVip[i];
                        numeroIngressoUltimoSaida = numeroVip[i];

                        // Remover e deslocar os vetores para frente
                        for (int j = i; j < contVip - 1; j++)
                        {
                            nomeVip[j] = nomeVip[j + 1];
                            idadeVip[j] = idadeVip[j + 1];
                            numeroVip[j] = numeroVip[j + 1];
                        }
                        // Limpar última posição
                        nomeVip[contVip - 1] = null;
                        idadeVip[contVip - 1] = 0;
                        numeroVip[contVip - 1] = 0;

                        contVip--;
                        tipo[numero] = null;

                        Console.WriteLine("Saída registrada com sucesso.");
                        return;
                    }
                }
                break;

            case "Comum":
                for (int i = 0; i < contComum; i++)
                {
                    if (numeroComum[i] == numero)
                    {
                        nomeUltimoSaida = nomeComum[i];
                        tipoUltimoSaida = "Comum";
                        idadeUltimoSaida = idadeComum[i];
                        numeroIngressoUltimoSaida = numeroComum[i];

                        for (int j = i; j < contComum - 1; j++)
                        {
                            nomeComum[j] = nomeComum[j + 1];
                            idadeComum[j] = idadeComum[j + 1];
                            numeroComum[j] = numeroComum[j + 1];
                        }
                        nomeComum[contComum - 1] = null;
                        idadeComum[contComum - 1] = 0;
                        numeroComum[contComum - 1] = 0;

                        contComum--;
                        tipo[numero] = null;

                        Console.WriteLine("Saída registrada com sucesso.");
                        return;
                    }
                }
                break;

            case "Prioritário":
                for (int i = 0; i < contPriori; i++)
                {
                    if (numeroPriori[i] == numero)
                    {
                        nomeUltimoSaida = nomePriori[i];
                        tipoUltimoSaida = "Prioritário";
                        idadeUltimoSaida = idadePriori[i];
                        numeroIngressoUltimoSaida = numeroPriori[i];

                        for (int j = i; j < contPriori - 1; j++)
                        {
                            nomePriori[j] = nomePriori[j + 1];
                            idadePriori[j] = idadePriori[j + 1];
                            numeroPriori[j] = numeroPriori[j + 1];
                        }
                        nomePriori[contPriori - 1] = null;
                        idadePriori[contPriori - 1] = 0;
                        numeroPriori[contPriori - 1] = 0;

                        contPriori--;
                        tipo[numero] = null;

                        Console.WriteLine("Saída registrada com sucesso.");
                        return;
                    }
                }
                break;

            default:
                Console.WriteLine("Tipo de ingresso inválido.");
                break;
        }
        Console.WriteLine("Espectador não encontrado ou já saiu.");
    }

    static void ConsultarIngresso(int entradaVip, int entradaComum, int entradaPriori, int contVip, int contComum, int contPriori)
    {
        System.Console.WriteLine("O número de ingressos VIPs disponiveis é " + (entradaVip - contVip));
        System.Console.WriteLine("O número de ingressos comuns disponiveis é " + (entradaComum - contComum));
        System.Console.WriteLine("O número de ingressos Prioritários disponiveis é " + (entradaPriori - contPriori));
    }
    static void ExibirResumo(int contVip, int contComum, int contPriori, int entradaVip, int entradaComum, int entradaPriori, string nomeUltimoEntrada, string tipoUltimoEntrada, int idadeUltimoEntrada, int numeroIngressoUltimoEntrada, string nomeUltimoSaida, string tipoUltimoSaida, int idadeUltimoSaida, int numeroIngressoUltimoSaida)
    {
        int totalPresentes = contVip + contComum + contPriori;

        Console.WriteLine("\n===== RESUMO DO EVENTO =====");
        Console.WriteLine("Número total de espectadores presentes: " + totalPresentes);

        if (totalPresentes > 0)
        {
            int percVip = (contVip * 100) / totalPresentes;
            int percComum = (contComum * 100) / totalPresentes;
            int percPriori = (contPriori * 100) / totalPresentes;

            Console.WriteLine("\nQuantidade e percentual por categoria:");
            Console.WriteLine($"VIP: {contVip} ({percVip}%)");
            Console.WriteLine($"Comum: {contComum} ({percComum}%)");
            Console.WriteLine($"Prioritário: {contPriori} ({percPriori}%)");
        }
        else
        {
            Console.WriteLine("Nenhum espectador presente no momento.");
        }

        Console.WriteLine("\nIngressos disponíveis por categoria:");
        Console.WriteLine("VIP: " + (entradaVip - contVip));
        Console.WriteLine("Comum: " + (entradaComum - contComum));
        Console.WriteLine("Prioritário: " + (entradaPriori - contPriori));

        Console.WriteLine("\nÚltimo espectador que entrou:");
        Console.WriteLine($"Nome: {nomeUltimoEntrada} | Tipo: {tipoUltimoEntrada} | Idade: {idadeUltimoEntrada} | Nº ingresso: {numeroIngressoUltimoEntrada}");

        Console.WriteLine("\nÚltimo espectador que saiu:");
        Console.WriteLine($"Nome: {nomeUltimoSaida} | Tipo: {tipoUltimoSaida} | Idade: {idadeUltimoSaida} | Nº ingresso: {numeroIngressoUltimoSaida}");
    }

    static void ExibirLista(string[] nomeVip, string[] nomeComum, string[] nomePriori, int[] idadeVip, int[] idadeComum, int[] idadePriori, int[] numeroVip, int[] numeroComum, int[] numeroPriori, int contVip, int contComum, int contPriori)
    {
        System.Console.WriteLine("-- VIPS --");
        for (int i = 0; i < nomeVip.Length; i++)
        {
            if (idadeVip[i] != 0)
                System.Console.WriteLine("Espectador: " + nomeVip[i] + " | idade: " + idadeVip[i] + " | n° Ingresso: " + numeroVip[i]);
        }
        if (contVip == 0)
            System.Console.WriteLine("Não há espectadores Vips presentes.");
        System.Console.WriteLine("-- Comuns --");

        for (int i = 0; i < nomeComum.Length; i++)
        {
            if (idadeComum[i] != 0)
                System.Console.WriteLine("Espectador: " + nomeComum[i] + " | idade: " + idadeComum[i] + " | n° Ingresso: " + numeroComum[i]);
        }
        if (contComum == 0)
            System.Console.WriteLine("Não há espectadores Comuns presentes.");

        System.Console.WriteLine("-- Prioritários --");

        for (int i = 0; i < nomePriori.Length; i++)
        {
            if (idadePriori[i] != 0)
                System.Console.WriteLine("Espectador: " + nomePriori[i] + " | idade: " + idadePriori[i] + " | n° Ingresso: " + numeroPriori[i]);
        }
        if (contPriori == 0)
            System.Console.WriteLine("Não há espectadores Prioritários presentes.");
    }

    static void Main()
    {
        /* Variáveis e aberturas para Arquivos */
        Stream entradaDados = File.Open("show_in.txt", FileMode.Open, FileAccess.Read);
        StreamReader leitor = new StreamReader(entradaDados);
        Stream saida = File.Open("show_out.txt", FileMode.Create, FileAccess.Write);
        StreamWriter escritor = new StreamWriter(saida);

        /* Pega o nome da cidade pelo arquivo */
        string cidade = leitor.ReadLine();

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

        int opcao, entrada = 0, contVip = 0, contComum = 0, contPriori = 0, idadeUltimoEntrada = 0, numeroIngressoUltimoEntrada = 0;
        /* Opcao para o menu */
        /* Entrada para quantas pessoas entraram no total */
        /* Conts para quantas pessoas entraram em cada categoria*/

        string nomeUltimoEntrada = "", tipoUltimoEntrada = "";
        /* UltimoEntrada para as informações do último espectador que entrou */

        string nomeUltimoSaida = "", tipoUltimoSaida = "";
        int idadeUltimoSaida = 0, numeroIngressoUltimoSaida = 0;

        

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
                    RegistrarSaida(tipo, nomeVip, nomeComum, nomePriori, idadeVip, idadeComum, idadePriori, numeroVip, numeroComum, numeroPriori, ref contVip, ref contComum, ref contPriori, ref nomeUltimoSaida, ref tipoUltimoSaida, ref idadeUltimoSaida, ref numeroIngressoUltimoSaida);
                    break;

                case 3:
                    ConsultarIngresso(entradaVip, entradaComum, entradaPriori, contVip, contComum, contPriori);
                    break;

                case 4:
                    ExibirResumo(contVip, contComum, contPriori, entradaVip, entradaComum, entradaPriori, nomeUltimoEntrada, tipoUltimoEntrada, idadeUltimoEntrada, numeroIngressoUltimoEntrada, nomeUltimoSaida, tipoUltimoSaida, idadeUltimoSaida, numeroIngressoUltimoSaida);
                    break;

                case 5:
                    ExibirLista(nomeVip, nomeComum, nomePriori, idadeVip, idadeComum, idadePriori, numeroVip, numeroComum, numeroPriori, contVip, contComum, contPriori);
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
        escritor.Close();
        entradaDados.Close();
        saida.Close();
    }
}
