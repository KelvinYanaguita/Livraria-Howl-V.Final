﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public string Endereço { get; set; }
        public string CPF { get; set; }

        public Cliente() { }

        private static int contadorId = 1;
        public Cliente(string nome, string email, int telefone, string endereço, string cpf)
        {
            Id = contadorId++;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereço = endereço;
            CPF = cpf;
            clientes.Add(this);
        }

        public void ExibirCliente()
        {
            Console.WriteLine($"id: {Id}");
            Console.WriteLine($"nome: {Nome}");
            Console.WriteLine($"email: {Email}");
            Console.WriteLine($"telefone:{Telefone}");
            Console.WriteLine($"endereço: {Endereço}");
            Console.WriteLine($"cpf: {CPF}");
        }


        public static List<Cliente> clientes = new List<Cliente>();

        static void ExibirCabecalho()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("------ Livraria Howl -----");
            Console.WriteLine("--------------------------");
        }
        public static void CadastrarCliente()
        {
            try
            {
                Console.Clear();
                ExibirCabecalho();
                Console.WriteLine("Adicionar Cliente");

                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome))
                {
                    throw new ArgumentException("Nome não pode ser vazio.");
                }

                Console.Write("Email: ");
                string email = Console.ReadLine();
                if (string.IsNullOrEmpty(email))
                {
                    throw new ArgumentException("Email não pode ser vazio.");
                }

                Console.Write("Telefone: ");
                if (!int.TryParse(Console.ReadLine(), out int telefone))
                {
                    throw new FormatException("Telefone deve ser um número inteiro.");
                }

                Console.Write("Endereço: ");
                string endereço = Console.ReadLine();
                if (string.IsNullOrEmpty(endereço))
                {
                    throw new ArgumentException("Endereço não pode ser vazio.");
                }

                Console.Write("CPF: ");
                string cpf = Console.ReadLine();
                if (string.IsNullOrEmpty(cpf))
                {
                    throw new ArgumentException("CPF não pode ser vazio.");
                }

                Cliente novoCliente = new Cliente(nome, email, telefone, endereço, cpf);

                Console.WriteLine($"O cliente '{nome}' foi cadastrado com sucesso!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Erro de formatação: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro de argumento: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }
        public static string BuscarNomePorId(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            return cliente != null ? cliente.Nome : $"Cliente {id}";
        }

        public static void ExcluirCliente()
        {
            Console.Clear();
            ExibirCabecalho();
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado ainda.");
            }
            else
            {
                Console.WriteLine("Lista Clientes:");
                Console.WriteLine();
                foreach (var cliente in clientes)
                {
                    cliente.ExibirCliente();

                    Console.WriteLine("-------------------------");
                }
            }
            Console.WriteLine("Excluir Cliente");

            try
            {
                Console.Write("ID do Cliente: ");
                if (!int.TryParse(Console.ReadLine(), out int idCliente))
                {
                    throw new FormatException("ID deve ser um número inteiro.");
                }

                var cliente = clientes.FirstOrDefault(c => c.Id == idCliente);
                if (cliente != null)
                {
                    clientes.Remove(cliente);
                    Console.WriteLine($"Cliente com ID {idCliente} foi excluído com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Cliente com ID {idCliente} não encontrado.");
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

        public static void ListarClientes()
        {
            Console.Clear();
            ExibirCabecalho();
            Console.WriteLine();

            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado ainda.");
            }
            else
            {
                Console.WriteLine("Lista Clientes:");
                Console.WriteLine();
                foreach (var cliente in clientes)
                {
                    cliente.ExibirCliente();

                    Console.WriteLine("-------------------------");
                }
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public static string ObterNomeCliente(List<Cliente> clientes, int idCliente)
        {
            Cliente cliente = clientes.Find(c => c.Id == idCliente);
            return cliente != null ? cliente.Nome : "Cliente não encontrado";
        }

        public static void SubmenuClientes()
        {
            int opcaoSubmenu = 0;

            while (opcaoSubmenu != 4)
            {
                Console.Clear();
                ExibirCabecalho();
                Console.WriteLine("Submenu Clientes");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Excluir Cliente");
                Console.WriteLine("4. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                if (int.TryParse(Console.ReadLine(), out opcaoSubmenu))
                {
                    switch (opcaoSubmenu)
                    {
                        case 1:
                            CadastrarCliente();
                            break;
                        case 2:
                            ListarClientes();
                            break;
                        case 3:
                            ExcluirCliente();
                            break;
                        case 4:
                            Program.MenuPrincipal();
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
    }


}





