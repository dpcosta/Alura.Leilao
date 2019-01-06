using Xunit;
using Alura.Leilao.Core;
using System.Collections.Generic;

namespace Alura.Leilao.Tests
{
    public class LeilaoMelhorLanceTestes
    {
        //primeira tentativa de não repetir código...
        private Core.Leilao CriaLeilao(string peca, double[] ofertas)
        {
            var leilao = new Core.Leilao(peca);
            var interessado = new Interessado("Fulano", leilao);
            foreach (var oferta in ofertas)
            {
                interessado.Oferece(oferta);
            }
            return leilao;
        }

        [Fact]
        public void TestaMaiorEMenorLances()
        {
            var leilao = CriaLeilao("Obra de Rembrant", new double[] { 1300, 1350, 1200 });
            var resultado = leilao.Termina();
            Assert.Equal(1350, resultado.MelhorLance.Valor);
        }

        [Fact]
        public void TestaLeilaoComClienteUnico()
        {
            var leilao = CriaLeilao("Obra de Rembrant", new double[] { 1200, 1300, 1350, 900 });

            var resultado = leilao.Termina();

            Assert.Equal(1350, resultado.MelhorLance.Valor);
            Assert.Equal("Fulano", resultado.MelhorLance.Cliente.Nome);
        }

        [Fact]
        public void TestaLeilaoComLanceUnico()
        {
            var leilao = CriaLeilao("Obra de Rembrant", new double[] { 1200 });

            var resultado = leilao.Termina();

            Assert.Equal(1200, resultado.MelhorLance.Valor);
        }

        [Fact]
        public void MaiorLanceRetornaZeroQuandoNaoHaLances()
        {
            var leilao = CriaLeilao("Escultura de Aleijadinho", new double[] { });

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
