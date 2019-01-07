using Xunit;
using Alura.Leilao.Core;

namespace Alura.Leilao.Tests
{
    public class LeilaoTermina
    {
        [Trait("Category", "Unit Tests")]
        [Fact]
        public void RetornaResultadoNaoNulo()
        {
            var leilao = new Core.Leilao("Pe�a qualquer");
            var resultado = leilao.Termina();
            Assert.NotNull(resultado);
        }

        [Trait("Category", "Unit Tests")]
        [Fact]
        public void DepoisDeInvocadoNaoPermiteNovosLances()
        {
            var leilao = new Core.Leilao("Pe�a qualquer");
            var resultado = leilao.Termina();
            new Interessado("Fulano", leilao).Oferece(250);
            Assert.Equal(0, leilao.Lances.Count);
        }

        [Trait("Category", "Unit Tests")]
        [Theory]
        [InlineData(0, new double[] { })]
        [InlineData(1200, new double[] { 1200 })]
        [InlineData(1350, new double[] { 1200, 1300, 1350, 900 })]
        public void RetornaMaiorOferta(
            double maiorLanceEsperado,
            double[] ofertas)
        {
            var leilao = new Core.Leilao("Pintura de Dal�");
            var joao = new Interessado("Jo�o de Miranda", leilao);

            foreach (var oferta in ofertas)
            {
                joao.Oferece(oferta);
            }

            var resultado = leilao.Termina();

            Assert.Equal(maiorLanceEsperado, resultado.MelhorLance.Valor);
        }
    }
}