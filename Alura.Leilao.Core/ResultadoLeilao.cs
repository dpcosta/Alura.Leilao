using System.Linq;

namespace Alura.Leilao.Core
{
    public class ResultadoLeilao
    {
        public Leilao Leilao { get; }
        public Lance MelhorLance { get; }

        public ResultadoLeilao(Leilao leilao)
        {
            Leilao = leilao;
            //MelhorLance = Lances.Last(); começar com esse código...
            MelhorLance = Leilao
                .Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(l => l.Valor)
                .LastOrDefault();
        }
    }
}
