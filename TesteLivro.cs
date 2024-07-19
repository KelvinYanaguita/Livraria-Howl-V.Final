using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleApp1
{
    public class TesteLivro
    {
        [Fact]
        public void AtualizarQuantidadeLivro()
        {
            var livro = new Livro("Título Teste", "Autor Teste", "Editora Teste", 100, 10);
            int quantidadeAdicionada = 3;
            int quantidadeEsperada = 13;

            Livro.AtualizarQuantidadeLivro(livro, quantidadeAdicionada);

            Assert.Equal(quantidadeEsperada, livro.Quantidade);
        }
    }
    public class VendaTests
    {
        [Fact]
        public void TestVendaValorTotalCalculation()
        {
            // Arrange
            int idFuncionario = 1;
            int idCliente = 1;
            decimal valorRecebido = 500.0m;

            List<ItemVenda> itensVenda = new List<ItemVenda>
            {
                new ItemVenda { IdLivro = 1, QuantidadeVendida = 2, PrecoUnitario = 100.0m },
                new ItemVenda { IdLivro = 2, QuantidadeVendida = 1, PrecoUnitario = 200.0m }
            };

            // Act
            Venda venda = new Venda(idFuncionario, idCliente, itensVenda, valorRecebido);

            // Assert
            Assert.Equal(400.0m, venda.ValorTotal);
        }

        [Fact]
        public void TestVendaValorRecebidoCalculation()
        {
            // Arrange
            int idFuncionario = 1;
            int idCliente = 1;
            decimal valorRecebido = 500.0m;

            List<ItemVenda> itensVenda = new List<ItemVenda>
            {
                new ItemVenda { IdLivro = 1, QuantidadeVendida = 2, PrecoUnitario = 100.0m },
                new ItemVenda { IdLivro = 2, QuantidadeVendida = 1, PrecoUnitario = 200.0m }
            };

            // Act
            Venda venda = new Venda(idFuncionario, idCliente, itensVenda, valorRecebido);

            // Assert
            Assert.Equal(valorRecebido, venda.ValorRecebido);
        }

        [Fact]
        public void TestVendaChangeCalculation()
        {
            // Arrange
            int idFuncionario = 1;
            int idCliente = 1;
            decimal valorRecebido = 500.0m;

            List<ItemVenda> itensVenda = new List<ItemVenda>
            {
                new ItemVenda { IdLivro = 1, QuantidadeVendida = 2, PrecoUnitario = 100.0m },
                new ItemVenda { IdLivro = 2, QuantidadeVendida = 1, PrecoUnitario = 200.0m }
            };

            // Act
            Venda venda = new Venda(idFuncionario, idCliente, itensVenda, valorRecebido);

            // Assert
            Assert.Equal(100.0m, venda.ValorRecebido - venda.ValorTotal);
        }
    }
}
