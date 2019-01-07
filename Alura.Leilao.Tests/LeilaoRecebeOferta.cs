using System.Linq;
using Xunit;
using Alura.Leilao.Core;

namespace Alura.Leilao.Tests
{
    public class LeilaoRecebeOferta
    {
        [Fact]
        public void NaoPermiteLancesConsecutivosDoMesmoCliente()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            var joao = new Interessado("João", leilao);
            leilao.Inicia();
            leilao.RecebeOferta(new Lance(joao, 180));
            leilao.RecebeOferta(new Lance(joao, 200));
            Assert.Equal(1, leilao.Lances.Count);
            Assert.Equal(180, leilao.Lances[0].Valor);
        }

        [Fact]
        public void NaoPermiteLancesMenoresDoMesmoCliente()
        {
            var leilao = new Core.Leilao("Peça qualquer");
            var joao = new Interessado("João", leilao);
            var maria = new Interessado("Maria", leilao);
            leilao.Inicia();
            leilao.RecebeOferta(new Lance(joao, 180));
            leilao.RecebeOferta(new Lance(maria, 200));
            leilao.RecebeOferta(new Lance(joao, 170));
            Assert.Equal(2, leilao.Lances.Count);
            var valorLanceJoao = leilao.Lances
                .Where(l => l.Cliente == joao)
                .Select(l => l.Valor)
                .First();
            Assert.Equal(180, valorLanceJoao);
        }
    }
}
