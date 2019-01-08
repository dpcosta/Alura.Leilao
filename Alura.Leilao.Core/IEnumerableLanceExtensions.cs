using System.Collections.Generic;
using System.Linq;
using Alura.Leilao.Core;

namespace Alura.Leilao.Core
{
    public static class IEnumerableLanceExtensions
    {
        public static bool UltimoLanceNaoEhDoCliente(
            this IEnumerable<Lance> lances, 
            Lance lance)
        {
            var ultimoCliente = lances.Select(l => l.Cliente).LastOrDefault();
            return (lance.Cliente != ultimoCliente);
        }

        public static bool ClienteNuncaDeuLanceMaior(this IEnumerable<Lance> lances,
            Lance lance)
        {
            return !lances.Any(l => 
                (l.Cliente == lance.Cliente) && 
                (l.Valor > lance.Valor));
        }
    }
}
