using System.Linq;

namespace Alura.Leilao.Core
{
    public class Avaliador
    {
        public Leilao Leilao { get; }
        public double MaiorLance { get; private set; } = double.MinValue;
        public double MenorLance { get; private set; } = double.MaxValue;

        public Avaliador(Leilao leilao)
        {
            Leilao = leilao;
        }

        public void Avalia()
        {
            foreach (var lance in Leilao.Lances)
            {
                if (lance.Valor > MaiorLance)
                {
                    MaiorLance = lance.Valor;
                }
                else if (lance.Valor < MenorLance)
                {
                    MenorLance = lance.Valor;
                }
            }
        }


    }
}
