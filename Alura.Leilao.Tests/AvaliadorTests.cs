using Xunit;
using Alura.Leilao.Core;

namespace Alura.Leilao.Tests
{
    public class AvaliadorTests
    {
        [Fact]
        public void TestaMaiorEMenorLances()
        {
            var joao = new Cliente("João de Miranda");
            var pedro = new Cliente("Pedro Silveira");
            var malu = new Cliente("Malu Pereira");
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");
            leilao.Propoe(new Lance(joao, 1200));
            leilao.Propoe(new Lance(pedro, 1300));
            leilao.Propoe(new Lance(malu, 1350));

            var leiloeiro = new Avaliador(leilao);
            leiloeiro.Avalia();

            Assert.Equal(1350, leiloeiro.MaiorLance);
            Assert.Equal(1200,leiloeiro.MenorLance);
        }
    }
}
