using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class VeiculoServicoTest
    {
        // Arrange
        private static DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }


        private VeiculoServico servico = new(CriarContextoDeTeste());


        [TestMethod]
        public void TestIncluir()
        {
            // Arrange
            Veiculo veiculo = new()
            {
                Ano = 2001,
                Id = 1,
                Marca = "Toyota",
                Nome = "Corola"
            };
            // Act
            servico.Incluir(veiculo);

            // Assert
            Assert.AreEqual(1, servico.Todos(1).Count);
            servico.Apagar(veiculo);
        }


        [TestMethod]
        public void TestApagar()
        {
            // Arrange
            Veiculo veiculo = new()
            {
                Ano = 2001,
                Id = 2,
                Marca = "Toyota",
                Nome = "Corola"
            };
            // Act
            servico.Incluir(veiculo);
            servico.Apagar(veiculo);

            // Assert
            Assert.AreEqual(1, servico.Todos(1).Count);

        }

        [TestMethod]
        public void TestAtualizar()
        {
            // Arrange
            Veiculo veiculo = new()
            {
                Ano = 2024,
                Id = 1,
                Marca = "Renaut",
                Nome = "Qwid"
            };
            // Act
            servico.Atualizar(veiculo);

            // Assert
            Assert.AreEqual(2024, veiculo.Ano);
            Assert.AreEqual("Renaut", veiculo.Marca);
            Assert.AreEqual("Qwid", veiculo.Nome);


        }

        [TestMethod]
        public void TestBuscaPorId()
        {
            // Arrange
            Veiculo veiculo = new()
            {
                Ano = 2024,
                Id = 4,
                Marca = "GTR",
                Nome = "Porshe"
            };
            // Act
            servico.Incluir(veiculo);
            Veiculo? veiculoDoBanco = servico.BuscaPorId(veiculo.Id);

            // Assert
            Assert.AreEqual(4, veiculoDoBanco?.Id);
        }
    }
}