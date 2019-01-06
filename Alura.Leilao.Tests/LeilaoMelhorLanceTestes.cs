using Xunit;
using Alura.Leilao.Core;

namespace Alura.Leilao.Tests
{
    public class LeilaoTermina
    {
        [Fact]
        public void RetornaResultadoNaoNulo()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            var resultado = leilao.Termina();
            Assert.NotNull(resultado);
        }

        [Theory]
        [InlineData(new double[] { })]
        [InlineData(new double[] { 1200 })]
        [InlineData(new double[] { 1200, 1300, 1350, 900 })]
        public void RetornaResultadoValido(double[] ofertas)
        {
            var leilao = new Core.Leilao("Pintura de Dalí");
            var joao = new Interessado("João de Miranda", leilao);

            foreach (var oferta in ofertas)
            {
                joao.Oferece(oferta);
            }

            var resultado = leilao.Termina();

            Assert.NotNull(resultado);
        }

        [Fact]
        public void DepoisDeInvocadoNaoPermiteNovosLances()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            var resultado = leilao.Termina();
            new Interessado("Fulano", leilao).Oferece(250);
            Assert.Equal(0, leilao.Lances.Count);
        }

        [Theory]
        [InlineData(new double[] { })]
        [InlineData(new double[] { 1200 })]
        [InlineData(new double[] { 1200, 1300, 1350, 900 })]
        public void DepoisDeChamadoNaoPermiteNovosLances(
            double[] ofertas)
        {
            var leilao = new Core.Leilao("Pintura de Dalí");
            var joao = new Interessado("João de Miranda", leilao);

            foreach (var oferta in ofertas)
            {
                joao.Oferece(oferta);
            }

            var qtdeLancesNoLeilao = leilao.Lances.Count;
            var resultado = leilao.Termina();

            joao.Oferece(double.MaxValue);

            Assert.Equal(qtdeLancesNoLeilao, leilao.Lances.Count);
        }


        [Theory]
        [InlineData(0, new double[] { })]
        [InlineData(1200, new double[] { 1200 })]
        [InlineData(1350, new double[] { 1200, 1300, 1350, 900 })]
        public void RetornaMaiorOferta(
            double maiorLanceEsperado,
            double[] ofertas)
        {
            var leilao = new Core.Leilao("Pintura de Dalí");
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
