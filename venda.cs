using ConsoleApp1;

public class ItemVenda
{
    public int IdLivro { get; set; }
    public int QuantidadeVendida { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal ValorTotal => PrecoUnitario * QuantidadeVendida;
}
public class Venda
{
    public int IdVenda { get; set; }
    public int IdFuncionario { get; set; }
    public int IdCliente { get; set; }
    public List<ItemVenda> ItensVenda { get; set; }
    public decimal ValorTotal => ItensVenda.Sum(item => item.ValorTotal);
    public decimal ValorRecebido { get; set; }

    private static List<Venda> vendas = new List<Venda>();
    private static int contadorId = 1;

    public Venda(int idFuncionario, int idCliente, List<ItemVenda> itensVenda, decimal valorRecebido)
    {
        IdVenda = contadorId++;
        IdFuncionario = idFuncionario;
        IdCliente = idCliente;
        ItensVenda = itensVenda;
        ValorRecebido = valorRecebido;

        foreach (var item in ItensVenda)
        {
            Livro livro = Livro.BuscarLivroPorId(item.IdLivro);
            if (livro != null)
            {
                Livro.AtualizarQuantidadeLivroVenda(livro, item.QuantidadeVendida);
            }
            else
            {
                Console.WriteLine($"Livro com ID {item.IdLivro} não encontrado!");
            }
        }

        vendas.Add(this);

        Console.WriteLine($"Venda realizada com sucesso!");
        Console.WriteLine($"Total a pagar: {ValorTotal:C}");
        Console.WriteLine($"Valor recebido: {ValorRecebido:C}");

        if (ValorRecebido < ValorTotal)
        {
            Console.WriteLine($"Falta: {(ValorTotal - ValorRecebido):C}");
        }
        else if (ValorRecebido > ValorTotal)
        {
            Console.WriteLine($"Troco: {(ValorRecebido - ValorTotal):C}");
        }
        else
        {
            Console.WriteLine("Pago!");
        }
    }

    static void ExibirCabecalho()
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine("------ Livraria Howl -----");
        Console.WriteLine("--------------------------");
    }

    public static void ListarVendas()
    {
        Console.Clear();
        ExibirCabecalho();
        if (vendas.Count == 0)
        {
            Console.WriteLine("Nenhuma venda registrada.");
        }
        else
        {
            Console.WriteLine("Lista Vendas");
            Console.WriteLine();
            foreach (var venda in vendas)
            {
                string nomeFuncionario = venda.NomeFuncionario();
                string nomeCliente = venda.NomeCliente();

                Console.WriteLine($"ID Venda: {venda.IdVenda} \n" +
                                   $" Funcionário: {nomeFuncionario} \n" +
                                   $" Cliente: {nomeCliente} \n" +
                                   $" Valor Total: {venda.ValorTotal:C}");
                Console.WriteLine();
                Console.WriteLine("Itens:");
                Console.WriteLine();
                foreach (var item in venda.ItensVenda)
                {
                    string tituloLivro = venda.TituloLivro(item.IdLivro);
                    Console.WriteLine($" Livro: {tituloLivro} \n" +
                                       $" Quantidade Vendida: {item.QuantidadeVendida} \n" +
                                       $" Valor Total: {item.ValorTotal:C}");
                    Console.WriteLine();
                }
                Console.WriteLine("-------------------------");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public string NomeFuncionario()
    {
        return Funcionario.BuscarNomePorId(IdFuncionario);
    }

    public string NomeCliente()
    {
        return Cliente.BuscarNomePorId(IdCliente);
    }

    public string TituloLivro(int idLivro)
    {
        return Livro.BuscarTituloPorId(idLivro);
    }

    public static void CadastrarVenda()
    {
        Console.Clear();
        ExibirCabecalho();
        Console.WriteLine("Cadastrar Venda");

        try
        {
            Console.Write("ID do Funcionário: ");
            int idFuncionario = int.Parse(Console.ReadLine());

            Console.Write("ID do Cliente: ");
            int idCliente = int.Parse(Console.ReadLine());

            List<ItemVenda> itensVenda = new List<ItemVenda>();

            while (true)
            {
                Console.Write("ID do Livro: ");
                int idLivro = int.Parse(Console.ReadLine());

                Console.Write("Quantidade Vendida: ");
                int quantidadeVendida = int.Parse(Console.ReadLine());

                Livro livro = Livro.BuscarLivroPorId(idLivro);
                if (livro != null)
                {
                    itensVenda.Add(new ItemVenda
                    {
                        IdLivro = idLivro,
                        QuantidadeVendida = quantidadeVendida,
                        PrecoUnitario = livro.Preco
                    });
                }
                else
                {
                    Console.WriteLine("Livro não encontrado!");
                }

                Console.Write("Deseja adicionar outro livro? (s/n): ");
                string resposta = Console.ReadLine().ToLower();
                if (resposta != "s")
                {
                    break;
                }
            }

            Console.Write("Valor Recebido: ");
            decimal valorRecebido = decimal.Parse(Console.ReadLine());

            new Venda(idFuncionario, idCliente, itensVenda, valorRecebido);
            Console.WriteLine("Venda cadastrada com sucesso!");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Entrada inválida. Por favor, insira valores corretos.");
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu um erro inesperado ao cadastrar a venda.");
            Console.WriteLine($"Erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void SubmenuVendas()
    {
        int opcaoSubmenu = 0;

        while (opcaoSubmenu != 3)
        {
            Console.Clear();
            ExibirCabecalho();
            Console.WriteLine();
            Console.WriteLine("Submenu Vendas");
            Console.WriteLine();
            Console.WriteLine("1. Cadastrar Venda");
            Console.WriteLine("2. Listar Vendas");
            Console.WriteLine("3. Voltar ao Menu Principal");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out opcaoSubmenu))
            {
                try
                {
                    switch (opcaoSubmenu)
                    {
                        case 1:
                            CadastrarVenda();
                            break;
                        case 2:
                            ListarVendas();
                            break;
                        case 3:
                            Program.MenuPrincipal();
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro ao processar sua opção.");
                    Console.WriteLine($"Erro: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
            }
        }
    }

    public override string ToString()
    {
        return $"ID Venda: {IdVenda}\n" +
               $" ID Funcionário: {IdFuncionario}\n" +
               $" ID Cliente: {IdCliente}\n" +
               $" Valor Total: {ValorTotal:C}";
    }
}


