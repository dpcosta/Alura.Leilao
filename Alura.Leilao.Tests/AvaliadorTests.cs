using Xunit;
using Alura.Leilao.Core;
using System.Collections.Generic;

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
            Assert.Equal(1200, leiloeiro.MenorLance);
        }

        [Fact]
        public void TestaLeilaoComClienteUnico()
        {
            var joao = new Cliente("João de Miranda");
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");
            leilao.Propoe(new Lance(joao, 1200));
            leilao.Propoe(new Lance(joao, 1300));
            leilao.Propoe(new Lance(joao, 1350));
            leilao.Propoe(new Lance(joao, 900));

            var leiloeiro = new Avaliador(leilao);
            leiloeiro.Avalia();

            Assert.Equal(1350, leiloeiro.MaiorLance);
            Assert.Equal(900, leiloeiro.MenorLance);
        }

        [Fact]
        public void TestaLeilaoComLanceUnico()
        {
            var joao = new Cliente("João de Miranda");
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");
            leilao.Propoe(new Lance(joao, 1200));

            var leiloeiro = new Avaliador(leilao);
            leiloeiro.Avalia();

            Assert.Equal(1200, leiloeiro.MaiorLance);
            Assert.Equal(1200, leiloeiro.MenorLance);

        }

        [Fact]
        public void MaiorLanceRetornaZeroQuandoNaoHaLances()
        {
            var joao = new Cliente("João de Miranda");
            var leilao = new Core.Leilao("Escultura de Aleijadinho");

            var leiloeiro = new Avaliador(leilao);
            leiloeiro.Avalia();

            Assert.Equal(0, leiloeiro.MaiorLance);
        }

        public static IEnumerable<object[]> Ofertas =>
            new List<object[]>
            {
                new object[] { 0, 0 },
                new object[] { 1200, 1200, new double[] { 1200 } },
                new object[] { 1350, 900, new double[] { 1200, 1350, 1300, 900, 970 } }
            };

        [Theory]
        [MemberData(nameof(Ofertas))]
        public void MenorLanceRetornaZeroQuandoNaoHaLances(
            double maiorLanceEsperado,
            double menorLanceEsperado,
            params double[] ofertas)
        {
            double[] teste = { };
            var joao = new Cliente("João de Miranda");
            var leilao = new Core.Leilao("Escultura de Aleijadinho");

            foreach (var oferta in ofertas)
            {
                leilao.Propoe(new Lance(joao, oferta));
            }

            var leiloeiro = new Avaliador(leilao);
            leiloeiro.Avalia();

            Assert.Equal(maiorLanceEsperado, leiloeiro.MaiorLance);
            Assert.Equal(menorLanceEsperado, leiloeiro.MenorLance);
        }
    }
}
