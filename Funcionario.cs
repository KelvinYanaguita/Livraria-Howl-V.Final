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
        }

    }

    public static void SubmenuFuncionarios()
    {
        int opcaoSubmenu = 0;

        while (opcaoSubmenu != 3)
        {
            Console.Clear();
            ExibirCabecalho();
            Console.WriteLine();
            Console.WriteLine("Submenu Funcionários");
            Console.WriteLine();
            Console.WriteLine("1. Adicionar Funcionário");
            Console.WriteLine("2. Listar Funcionários");
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
                            CadastrarFuncionario();
                            break;
                        case 2:
                            ListarFuncionarios();
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

    public override string ToString()
    {
        return $"ID: {IdFuncionario}, Nome: {Nome}, Cargo ID: {IdCargo}, Salário: {Salario:C}, CTPS: {CarteiraDeTrabalho}, Registrado: {Registrado}";
    }
}
