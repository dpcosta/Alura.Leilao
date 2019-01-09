using System.Linq;

namespace Alura.Leilao.Core
{
    public class ResultadoLeilao
    {
        public Leilao Leilao { get; }
        public Lance MelhorLance { get; }

        public ResultadoLeilao(Leilao leilao, Lance melhorLance)
        {
            Leilao = leilao;
            MelhorLance = melhorLance;
        }
    }
}
