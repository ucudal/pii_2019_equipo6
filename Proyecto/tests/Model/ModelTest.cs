using System;
using Xunit;
using RazorPagesMovie.Models;

namespace tests
{
    public class UnitTest
    {
        [Fact]
        public void ClientTest()
        {
            Client cliente = new Client();
            Assert.IsType<Client>(cliente);
        }
    }
}