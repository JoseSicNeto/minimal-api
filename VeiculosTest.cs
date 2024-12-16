using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculosTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange

            Veiculo veiculo = new()
            {
                // Act
                Ano = 2001,
                Id = 1,
                Marca = "Toyota",
                Nome = "Corola"
            };

            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Toyota", veiculo.Marca);
            Assert.AreEqual("Corola", veiculo.Nome);
            Assert.AreEqual(2001, veiculo.Ano);
        }
    }
}