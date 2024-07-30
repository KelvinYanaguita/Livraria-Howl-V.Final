using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;

public class Funcionario
{
    public int IdFuncionario { get; set; }
    public string Nome { get; set; }
    public int IdCargo { get; set; }

    public decimal Salario { get; set; }
    public string CarteiraDeTrabalho { get; set; }
    public bool Registrado { get; set; }

    private static List<Funcionario> funcionarios = new List<Funcionario>();
    private static int contadorId = 1;

    public Funcionario(string nome, int idCargo, decimal salario, string carteiraDeTrabalho, bool registrado = true)
    {
        IdFuncionario = contadorId++;
        Nome = nome;
        IdCargo = idCargo;

        Salario = salario;
        CarteiraDeTrabalho = carteiraDeTrabalho;
        Registrado = registrado;

        funcionarios.Add(this);
    }


    public string NomeCargo()
    {
        return Cargo.BuscarCargoPorId(IdCargo);
    }


    public static string BuscarNomePorId(int id)
    {
        var funcionario = funcionarios.FirstOrDefault(f => f.IdFuncionario == id);
        return funcionario != null ? funcionario.Nome : $"Funcionário {id}";
    }

    static void ExibirCabecalho()
    {
        Console.WriteLine("--------------------------");
        Console.WriteLine("------ Livraria Howl -----");
        Console.WriteLine("--------------------------");
    }

    public static void CadastrarFuncionario()
    {
        Console.Clear();
        ExibirCabecalho();
        Console.WriteLine("Adicionar Funcionário");

        try
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }

            Console.Clear();
            ExibirCabecalho();
            Console.WriteLine("1 - Gerente ; 2 - Atendente ; 3 - Estoquista");
            Console.Write("ID do Cargo: ");
            int idCargo;
            if (!int.TryParse(Console.ReadLine(), out idCargo) || idCargo < 1 || idCargo > 3)
            {
                throw new ArgumentException("ID do Cargo inválido.");
            }



            Console.Clear();
            ExibirCabecalho();
            Console.Write("Salário: ");
            decimal salario;
            if (!decimal.TryParse(Console.ReadLine(), out salario) || salario <= 0)
            {
                throw new ArgumentException("Salário inválido.");
            }

            Console.Clear();
            ExibirCabecalho();
            Console.Write("Carteira de Trabalho: ");
            string carteiraDeTrabalho = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(carteiraDeTrabalho))
            {
                throw new ArgumentException("Carteira de Trabalho não pode ser vazia.");
            }

            new Funcionario(nome, idCargo, salario, carteiraDeTrabalho);
            Console.WriteLine($"Funcionário '{nome}' adicionado com sucesso!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro de validação: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocorreu um erro inesperado ao cadastrar o funcionário. Erro: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    public static void ExcluirFuncionario()
    {
        Console.Clear();
        ExibirCabecalho();
        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
        }
        else
        {
            Console.WriteLine("Listagem de Funcionários");
            Console.WriteLine();
            foreach (var funcionario in funcionarios)
            {
                string nomeCargo = funcionario.NomeCargo();
                Console.WriteLine($" ID Funcionario: {funcionario.IdFuncionario} \n" +
                                  $" Nome: {funcionario.Nome} \n" +
                                  $" Cargo: {nomeCargo} \n" +
                                  $" Salário: {funcionario.Salario:C} \n" +
                                  $" Carteira de Trabalho: {funcionario.CarteiraDeTrabalho}");
                Console.WriteLine("-------------------------------");
            }
        }
        Console.WriteLine("Excluir Cliente");

        try
        {
            Console.Write("ID do Funcionario: ");
            if (!int.TryParse(Console.ReadLine(), out int idFuncionario))
            {
                throw new FormatException("ID deve ser um número inteiro.");
            }

            var funcionario = funcionarios.FirstOrDefault(f => f.IdFuncionario == idFuncionario);
            if (funcionario != null)
            {
                funcionarios.Remove(funcionario);
                Console.WriteLine($"Funcionario com ID {idFuncionario} foi excluído com sucesso.");
            }
            else
            {
                Console.WriteLine($"Funcionario com ID {idFuncionario} não encontrado.");
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

    public static void ListarFuncionarios()
    {
        Console.Clear();
        ExibirCabecalho();
        Console.WriteLine();
        if (funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
        }
        else
        {
            Console.WriteLine("Listagem de Funcionários");
            Console.WriteLine();
            foreach (var funcionario in funcionarios)
            {
                string nomeCargo = funcionario.NomeCargo();
                Console.WriteLine($" ID Funcionario: {funcionario.IdFuncionario} \n" +
                                  $" Nome: {funcionario.Nome} \n" +
                                  $" Cargo: {nomeCargo} \n" +
                                  $" Salário: {funcionario.Salario:C} \n" +
                                  $" Carteira de Trabalho: {funcionario.CarteiraDeTrabalho}");
                Console.WriteLine("-------------------------------");
               
            }
        } Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();

    }

    public static void SubmenuFuncionarios()
    {
        int opcaoSubmenu = 0;

        while (opcaoSubmenu != 4)
        {
            Console.Clear();
            ExibirCabecalho();
            Console.WriteLine("Submenu Funcionarios");
            Console.WriteLine("1. Adicionar Funcionario");
            Console.WriteLine("2. Listar Funcionarios");
            Console.WriteLine("3. Excluir Funcionario");
            Console.WriteLine("4. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out opcaoSubmenu))
            {
                switch (opcaoSubmenu)
                {
                    case 1:
                        CadastrarFuncionario();
                        break;
                    case 2:
                        ListarFuncionarios();
                        break;
                    case 3:
                        ExcluirFuncionario();
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

    public override string ToString()
    {
        return $"ID: {IdFuncionario}, Nome: {Nome}, Cargo ID: {IdCargo}, Salário: {Salario:C}, CTPS: {CarteiraDeTrabalho}, Registrado: {Registrado}";
    }
}
