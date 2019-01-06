using Xunit;
using Alura.Leilao.Core;
using System.Collections.Generic;

namespace Alura.Leilao.Tests
{
    public class LeilaoMelhorLanceTestes
    {
        [Fact]
        public void TestaMaiorEMenorLances()
        {
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");

            var joao = new Interessado("João de Miranda", leilao);
            var pedro = new Interessado("Pedro Silveira", leilao);
            var malu = new Interessado("Malu Pereira", leilao);

            pedro.Oferece(1300);
            malu.Oferece(1350);
            joao.Oferece(1200);

            var resultado = leilao.Termina();

            Assert.Equal(1350, resultado.MelhorLance.Valor);
        }

        [Fact]
        public void TestaLeilaoComClienteUnico()
        {
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");

            var joao = new Interessado("João de Miranda", leilao);

            joao.Oferece(1200);
            joao.Oferece(1300);
            joao.Oferece(1350);
            joao.Oferece(900);

            var resultado = leilao.Termina();

            Assert.Equal(1350, resultado.MelhorLance.Valor);
            Assert.Equal(joao.Nome, resultado.MelhorLance.Cliente.Nome);
        }

        [Fact]
        public void TestaLeilaoComLanceUnico()
        {
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");
            var joao = new Interessado("João de Miranda", leilao);

            joao.Oferece(1200);

            var resultado = leilao.Termina();

            Assert.Equal(1200, resultado.MelhorLance.Valor);
        }

        [Fact]
        public void MaiorLanceRetornaZeroQuandoNaoHaLances()
        {
            var leilao = new Core.Leilao("Escultura de Aleijadinho");
            var joao = new Interessado("João de Miranda", leilao);

            var resultado = leilao.Termina();

            Assert.Equal(0, resultado.MelhorLance.Valor);
        }

        public static IEnumerable<object[]> Ofertas =>
            new List<object[]>
            {
                new object[] { 0 },
                new object[] { 1200, new double[] { 1200 } },
                new object[] { 1350, new double[] { 1200, 1350, 1300, 900, 970 } }
            };

        [Theory]
        [MemberData(nameof(Ofertas))]
        public void MenorLanceRetornaZeroQuandoNaoHaLances(
            double maiorLanceEsperado,
            params double[] ofertas)
        {
            double[] teste = { };
            var leilao = new Core.Leilao("Escultura de Aleijadinho");
            var joao = new Interessado("João de Miranda", leilao);

            foreach (var oferta in ofertas)
            {
                joao.Oferece(oferta);
            }

            var resultado = leilao.Termina();

            Assert.Equal(maiorLanceEsperado, resultado.MelhorLance.Valor);
        }
    }
}
