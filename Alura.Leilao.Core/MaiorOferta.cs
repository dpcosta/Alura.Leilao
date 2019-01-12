using System.Linq;

namespace Alura.Leilao.Core
{
    public class MaiorOferta : IEstrategiaAvaliacao
    {
        public ResultadoLeilao Avalia(Leilao leilao)
        {
            var lance = leilao
                .Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(l => l.Valor)
                .LastOrDefault();
            return new ResultadoLeilao(lance);
        }
    }

}