using System.Linq;

namespace Alura.Leilao.Core
{
    public class OfertaSuperiorMaisProxima : IEstrategiaAvaliacao
    {
        public double ValorDestino { get; }
        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            ValorDestino = valorDestino;
        }

        public ResultadoLeilao Avalia(Leilao leilao)
        {
            var lance = leilao
                .Lances
                .Where(l => l.Valor > ValorDestino)
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(l => l.Valor)
                .FirstOrDefault();

            return new ResultadoLeilao(leilao, lance);

        }
    }
}
