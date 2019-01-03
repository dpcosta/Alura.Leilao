using System.Collections.Generic;

namespace Alura.Leilao.Core
{
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

        /// <summary>
        /// Cria uma instância de <see cref="Leilao"/> para <paramref name="descricao"/>.
        /// </summary>
        /// <param name="descricao"> Descrição do bem sendo leiloado.</param>
        public Leilao(string descricao)
        {
            Descricao = descricao;
            Lances = new List<Lance>();
        }

        /// <summary>
        /// Quando ocorre uma oferta de <see cref="Lance"/>.
        /// </summary>
        /// <param name="lance"> Lance sendo dado.</param>
        public void Propoe(Lance lance)
        {
            Lances.Add(lance);
        }
    }
}
