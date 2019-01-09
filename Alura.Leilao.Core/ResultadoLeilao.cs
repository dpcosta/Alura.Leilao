using System.Linq;

namespace Alura.Leilao.Core
{
    public class ResultadoLeilao
    {
        public Leilao Leilao { get; }
        public Lance MelhorLance { get; }
        public double ValorDestino { get; }

        public ResultadoLeilao(Leilao leilao, double valorDestino = 0)
        {
            Leilao = leilao;
            //MelhorLance = Lances.Last(); começar com esse código...
            var candidados = Leilao
                .Lances
                .Where(l => l.Valor > valorDestino)
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(l => l.Valor);

            if (valorDestino > 0)
            {
                MelhorLance = candidados.FirstOrDefault();
            } else
            {
                MelhorLance = candidados.LastOrDefault();
            }
        }
    }
}
