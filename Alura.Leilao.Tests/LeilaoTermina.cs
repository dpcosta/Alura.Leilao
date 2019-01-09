using System;
using Xunit;
using Alura.Leilao.Core;
using System.Globalization;

namespace Alura.Leilao.Tests
{
    public class LeilaoTermina
    {
        [Trait("Category", "Unit Tests")]
        [Fact]
        public void RetornaResultadoNaoNulo()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            leilao.Inicia();
            var resultado = leilao.Termina();
            Assert.NotNull(resultado);
        }

        [Trait("Category", "Unit Tests")]
        [Fact]
        public void DepoisDeInvocadoNaoPermiteNovosLances()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            leilao.Inicia();
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
            var leilao = new Core.Leilao("Pintura de Dalí");

            leilao.Inicia();
            foreach (var oferta in ofertas)
            {
                leilao.RecebeOferta(
                    new Lance(new Interessado("Fulano", leilao), oferta)
                );
            }

            var resultado = leilao.Termina();

            Assert.Equal(maiorLanceEsperado, resultado.MelhorLance.Valor);
        }

        [Theory]
        [InlineData(0, 900, new double[] { 800, 870, 880 })]
        [InlineData(900, 890, new double[] { 900 })]
        [InlineData(1250, 1200, new double[] { 800, 1150, 1300, 1250 })]
        public void RetornaOfertaSuperiorMaisProxima(
            double valorEsperado,
            double valorDestino,
            double[] ofertas)
        {
            var leilao = new Core.Leilao("Peça qualquer", valorDestino);
            leilao.Inicia();
            foreach (var oferta in ofertas)
            {
                var interessado = new Interessado("Fulano", leilao);
                var lance = new Lance(interessado, oferta);
                leilao.RecebeOferta(lance);
            }

            var resultado = leilao.Termina();
            Assert.Equal(valorEsperado, resultado.MelhorLance.Valor);
        }

        [Fact]
        public void DadoLeilaoAntesPregaoDeveLancarInvalidOperationException()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            var excecaoEsperada = Assert
                .Throws<InvalidOperationException>(() => leilao.Termina());
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
            Assert.Equal(
                "Leilão não pode ser finalizado antes do pregão começar.",
                excecaoEsperada.Message);
        }
    }
}
