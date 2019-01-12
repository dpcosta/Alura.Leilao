using System.Linq;

namespace Alura.Leilao.Core
{
    public class ResultadoLeilao
    {
        public Lance MelhorLance { get; }

        public ResultadoLeilao(Lance melhorLance)
        {
            MelhorLance = melhorLance;
        }
    }
}
