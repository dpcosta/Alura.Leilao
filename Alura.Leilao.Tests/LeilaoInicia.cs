using Xunit;
using Alura.Leilao.Core;

namespace Alura.Leilao.Tests
{
    public class LeilaoInicia
    {
        [Fact]
        public void ColocaStatusComoLeilaoEmAndamento()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            leilao.Inicia();
            Assert.Equal(StatusLeilao.LeilaoEmAndamento, leilao.Status);
        }

        [Fact]
        public void AntesDeInvocadoNaoPermiteLances()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            var joao = new Interessado("Fulano de tal", leilao);
            leilao.RecebeOferta(new Lance(joao, 901));
            leilao.RecebeOferta(new Lance(joao, 1349));
            Assert.Equal(0, leilao.Lances.Count);
        }

        [Fact]
        public void DepoisDeInvocadoAceitaLances()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            var joao = new Interessado("Fulano de tal", leilao);
            var maria = new Interessado("Maria", leilao);
            leilao.Inicia();
            leilao.RecebeOferta(new Lance(joao, 901));
            leilao.RecebeOferta(new Lance(maria, 1349));
            Assert.Equal(2, leilao.Lances.Count);
        }
    }
}
