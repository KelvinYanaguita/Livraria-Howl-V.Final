using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Cargo
    {
        public int IdCargo { get; set; }
        public string Nome { get; set; }

        public Cargo(string nome)
        {
            IdCargo = contadorId++;
            Nome = nome;
            cargos.Add(this);

        }
        private static List<Cargo> cargos = new List<Cargo>();
        private static int contadorId = 1;

        public static string BuscarCargoPorId(int id)
        {
            var cargo = cargos.FirstOrDefault(c => c.IdCargo == id);
            return cargo != null ? cargo.Nome : $"Cargo: {id}";
        }



    }
}
