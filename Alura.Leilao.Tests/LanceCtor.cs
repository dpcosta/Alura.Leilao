namespace Alura.Leilao.Tests
{
    using Xunit;
    using Alura.Leilao.Core;
    using System;

    public class LanceCtor
    {
        [Fact]
        public void ComValorNegativoLancaArgumentException()
        {
            var mensagemErroEsperada = "Lance inválido: valor deve ser maior que zero.";
            var excecaoRetornada = Assert.Throws<ArgumentException>(
                () => new Lance(null, -1)
            );
            Assert.Equal(mensagemErroEsperada, excecaoRetornada.Message);
        }
    }
}
