namespace ConsoleApp1
{
    internal class Program
    {

        static void ExibirCabecalho()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("------ Livraria Howl -----");
            Console.WriteLine("--------------------------");
        }

        public static void MenuPrincipal()
        {

            int opcao = 0;

            while (opcao != 5)
            {
                Console.Clear();
                ExibirCabecalho();
                Console.WriteLine("Bem vindo a livraria Howl!");
                Console.WriteLine();
                Console.WriteLine("Menu Principal");
                Console.WriteLine();
                Console.WriteLine("1. Livros");
                Console.WriteLine("2. Clientes");
                Console.WriteLine("3. Funcionarios");
                Console.WriteLine("4. Vendas");
                Console.WriteLine("5. Sair");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");


                string entrada = Console.ReadLine();

                if (int.TryParse(entrada, out opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            Livro.SubmenuLivros();
                            break;
                        case 2:
                            Cliente.SubmenuClientes();
                            break;
                        case 3:
                            Funcionario.SubmenuFuncionarios();
                            break;
                        case 4:
                            Venda.SubmenuVendas();
                            break;
                        case 5:
                            Console.WriteLine("Saindo...");
                            break;
                        default:
                            Console.WriteLine("Opção inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }
            }
        }
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            List<ItemVenda> itensVenda = new List<ItemVenda>
            {
                new ItemVenda { IdLivro = 1, QuantidadeVendida = 2, PrecoUnitario = 100.0m },
                new ItemVenda { IdLivro = 2, QuantidadeVendida = 1, PrecoUnitario = 200.0m }
            };

            int idFuncionario = 2;
            int idCliente = 2;
            decimal valorRecebido = 90.0m;

            Venda venda = new Venda(idFuncionario, idCliente, itensVenda, valorRecebido);
            List<ItemVenda> itensVenda1 = new List<ItemVenda>
            {
                new ItemVenda { IdLivro = 1, QuantidadeVendida = 2, PrecoUnitario = 100.0m },
                new ItemVenda { IdLivro = 2, QuantidadeVendida = 1, PrecoUnitario = 200.0m }
            };

            idFuncionario = 3;
            idCliente = 1;
            valorRecebido = 90.0m;

            Venda venda1 = new Venda(idFuncionario, idCliente, itensVenda, valorRecebido);

            new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", "HarperCollins", 120, 10);
            new Livro("1984", "George Orwell", "Companhia das Letras", 45, 15);
            new Livro("O Hobbit", "J.R.R. Tolkien", "HarperCollins", 70, 5);
            new Cliente("Jubileu 1", "jubileu1@test.com", 1234567890, "rua teste 1", "12345678900");
            new Cliente("Jubileu 2", "jubileu2@test.com", 1234567891, "rua teste 2", "12345678901");
            new Cliente("Jubileu 3", "jubileu3@test.com", 1234567892, "rua teste 3", "12345678902");
            new Funcionario("Balotelli", 1, 1900, "Carteira 01", true);
            new Funcionario("Kaka", 3, 1500, "Carteira 02", true);
            new Funcionario("Ronaldinho", 2, 1600, "Carteira 03", true);

            new Cargo("Gerente");
            new Cargo("Atendente");
            new Cargo("Ajudante Geral");

            MenuPrincipal();

        }

    }
}
