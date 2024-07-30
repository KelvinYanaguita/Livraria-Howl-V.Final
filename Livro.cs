using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Livro
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Autor { get; set; }
        public int Preco { get; set; }
        public int Quantidade { get; set; }

        private static List<Livro> livros = new List<Livro>();
        private static int contadorId = 1;

        public Livro(string titulo, string autor, string editora, int preco, int quantidade)
        {
            IdLivro = contadorId++;
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Preco = preco;
            Quantidade = quantidade;

            livros.Add(this);
        }


        static void ExibirCabecalho()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("------ Livraria Howl -----");
            Console.WriteLine("--------------------------");
        }

        public static void ExcluirLivro()
        {
            Console.Clear();
            ExibirCabecalho();
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado ainda.");
            }
            else
            {

                Console.WriteLine("Listagem de Livros:");
                Console.WriteLine();

                foreach (var livro in livros.Distinct().ToList())
                {
                    livro.ExibirLivros();
                    Console.WriteLine("-------------------------");
                }
            }
            Console.WriteLine("Excluir Livro");

            try
            {
                Console.Write("ID do Livro: ");
                if (!int.TryParse(Console.ReadLine(), out int idLivro))
                {
                    throw new FormatException("ID deve ser um número inteiro.");
                }

                var livro = livros.FirstOrDefault(l => l.IdLivro == idLivro);
                if (livro != null)
                {
                    livros.Remove(livro);
                    Console.WriteLine($"Cliente com ID {idLivro} foi excluído com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Cliente com ID {idLivro} não encontrado.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro de formatação: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        public static Livro BuscarLivroPorId(int id)
        {
            return livros.FirstOrDefault(l => l.IdLivro == id);
        }

        public static string BuscarTituloPorId(int id)
        {
            Livro livro = BuscarLivroPorId(id);
            return livro != null ? livro.Titulo : "Livro não encontrado";
        }

        public static void AtualizarQuantidadeLivroVenda(Livro livro, int quantidadeVendida)
        {
            livro.Quantidade -= quantidadeVendida;
        }

        public void ExibirLivros()
        {
            Console.WriteLine($"IdLivro: {IdLivro}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Editora: {Editora}");
            Console.WriteLine($"Preco: {Preco}");
            Console.WriteLine($"Quantidade: {Quantidade}");
        }

        public static void CadastrarLivro()
        {
            Console.Clear();
            ExibirCabecalho();
            Console.WriteLine("Adicionar Livro");

            try
            {
                string titulo = LerEntrada("Título: ");
                string autor = LerEntrada("Autor(a): ");
                string editora = LerEntrada("Editora: ");
                int preco = LerInteiroPositivo("Preço: ");
                int quantidade = LerInteiroPositivo("Quantidade: ");

                Livro livroExistente = livros
                    .FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

                if (livroExistente != null)
                {
                    Console.WriteLine("Já tem um livro cadastrado com esse nome!");

                    int quantidadeParaAdicionar = LerInteiroPositivo("Digite quantos livros você quer adicionar: ");
                    AtualizarQuantidadeLivro(livroExistente, quantidadeParaAdicionar);

                    Console.WriteLine($"A quantidade do livro '{livroExistente.Titulo}' foi atualizada para {livroExistente.Quantidade}.");
                }
                else
                {
                    livros.Add(new Livro(titulo, autor, editora, preco, quantidade));
                    Console.WriteLine($"O livro '{titulo}' foi adicionado com sucesso!");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro de validação: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro inesperado ao cadastrar o livro. Erro: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        public static void ListarLivros()
        {
            Console.Clear();
            ExibirCabecalho();
            Console.WriteLine();

            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado ainda.");
            }
            else
            {

                Console.WriteLine("Listagem de Livros:");
                Console.WriteLine();

                foreach (var livro in livros.Distinct().ToList())
                {
                    livro.ExibirLivros();
                    Console.WriteLine("-------------------------");
                }
            }

        }

        public static void AtualizarQuantidadeLivro(Livro livro, int quantidadeParaAdicionar)
        {
            livro.Quantidade += quantidadeParaAdicionar;
        }

        public static void SubmenuLivros()
        {
            int opcaoSubmenu = 0;

            while (opcaoSubmenu != 4)
            {
                Console.Clear();
                ExibirCabecalho();
                Console.WriteLine();
                Console.WriteLine("Submenu Livros");
                Console.WriteLine();
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Listar Livros");
                Console.WriteLine("3. Excluir Livros");
                Console.WriteLine("4. Voltar ao Menu Principal");
                Console.WriteLine();
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcaoSubmenu))
                {
                    try
                    {
                        switch (opcaoSubmenu)
                        {
                            case 1:
                                CadastrarLivro();
                                break;
                            case 2:
                                ListarLivros();
                                break;
                            case 3:
                                ExcluirLivro();
                                break;
                            case 4:
                                Program.MenuPrincipal();
                                break;
                            default:
                                Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocorreu um erro ao processar sua opção. Erro: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Tente novamente.");
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static string LerEntrada(string mensagem)
        {
            string entrada;
            do
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    Console.WriteLine("O campo não pode ser vazio ou conter apenas espaços em branco. Tente novamente.");
                }
            } while (string.IsNullOrWhiteSpace(entrada));
            return entrada;
        }

        private static int LerInteiroPositivo(string mensagem)
        {
            int valor;
            do
            {
                Console.Write(mensagem);
                if (!int.TryParse(Console.ReadLine(), out valor) || valor <= 0)
                {
                    Console.WriteLine("Por favor, digite um número válido maior que 0.");
                }
            } while (valor <= 0);
            return valor;
        }

        public override string ToString()
        {
            return $"ID: {IdLivro}, Título: {Titulo}, Autor: {Autor}, Editora: {Editora}, Preço: {Preco}, Quantidade: {Quantidade}";
        }
    }
}
