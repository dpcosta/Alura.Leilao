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
            if (Leilao.Lances.Count == 0)
            {
                MaiorLance = 0;
                MenorLance = 0;
            }
            foreach (var lance in Leilao.Lances)
            {
                if (lance.Valor > MaiorLance)
                {
                    MaiorLance = lance.Valor;
                }
                if (lance.Valor < MenorLance)
                {
                    MenorLance = lance.Valor;
                }
            }
        }


    }
}
