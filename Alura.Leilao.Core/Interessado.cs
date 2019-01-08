namespace Alura.Leilao.Core
{
    /// <summary>
    /// Representa o <see cref="Interessado"/>que faz o <see cref="Lance"/> no <see cref="Leilao"/>.
    /// </summary>
    public class Interessado
    {
        public string Nome { get; }

        public Leilao Leilao { get; }

        /// <summary>
        /// <see cref="Interessado"/> no <paramref name="leilao"/> com <paramref name="nome"/>.
        /// </summary>
        /// <param name="nome"> Nome do <see cref="Interessado"/></param>
        /// <param name="leilao"> Leilão que está interessado. </param>
        public Interessado(string nome, Leilao leilao)
        {
            Nome = nome;
            Leilao = leilao;
        }

        public void Oferece(double valor)
        {
            Leilao.RecebeOferta(new Lance(this, valor));
        }
    }
}