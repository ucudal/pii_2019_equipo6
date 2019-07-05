using System;
using Xunit;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Tests
{
    public class SimpleModelTests
    {
        [Fact]
        public void ClientTypeTest()
        {
            Client cliente = new Client();
            Assert.IsType<Client>(cliente);
        }

        [Fact]
        public void SpecializationCreationTest()
        {
            Specialization specialization = new Specialization();

            int numero = 5;
            string name = "Aguatero";
            int salary = 200;

            specialization.ID = numero;
            specialization.Name = name;
            specialization.Salary = salary;

            Assert.Equal(numero, specialization.ID);
            Assert.Equal(name, specialization.Name);
            Assert.Equal(salary, specialization.Salary);

        }
    }
}

