using System.Collections.Generic;
using System.Linq;

namespace Alura.Leilao.Core
{
    public enum StatusLeilao
    {
        LeilaoAntesPregao,
        LeilaoEmAndamento,
        LeilaoFinalizado
    }

    /// <summary>
    /// Venda de um bem definido em <see cref="Descricao"/> pela melhor oferta de <see cref="Lance"/>.
    /// </summary>
    public class Leilao
    {
        /// <summary>
        /// Bem sendo leiloado.
        /// </summary>
        public string Descricao { get; }

        /// <summary>
        /// Lances dados no leilão.
        /// </summary>
        public IList<Lance> Lances { get; }

        public StatusLeilao Status { get; private set; }

        /// <summary>
        /// Cria uma instância de <see cref="Leilao"/> para <paramref name="descricao"/>.
        /// </summary>
        /// <param name="descricao"> Descrição do bem sendo leiloado.</param>
        public Leilao(string descricao)
        {
            Descricao = descricao;
            Lances = new List<Lance>();
            Status = StatusLeilao.LeilaoAntesPregao;
        }

        /// <summary>
        /// Quando ocorre uma oferta de <see cref="Lance"/>.
        /// </summary>
        /// <param name="lance"> Lance sendo dado.</param>
        public void RecebeOfertaDe(Lance lance)
        {
            if (Status == StatusLeilao.LeilaoEmAndamento)
            {
                Lances.Add(lance);
            }
        }

        public void Inicia()
        {
            Status = StatusLeilao.LeilaoEmAndamento;
        }

        public ResultadoLeilao Termina()
        {
            Status = StatusLeilao.LeilaoFinalizado;
            return new ResultadoLeilao(this);
        }
    }
}
