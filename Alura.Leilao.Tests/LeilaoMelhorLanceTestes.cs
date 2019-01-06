using Xunit;
using Alura.Leilao.Core;

namespace Alura.Leilao.Tests
{
    public class LeilaoMelhorLanceTestes
    {
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
