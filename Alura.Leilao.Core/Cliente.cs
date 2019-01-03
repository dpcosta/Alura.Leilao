namespace Alura.Leilao.Core
{
    /// <summary>
    /// Representa o <see cref="Cliente"/>que faz o <see cref="Lance"/> no <see cref="Leilao"/>.
    /// </summary>
    public class Cliente
    {
        public string Nome { get; }

        /// <summary>
        /// Cria uma instância de <see cref="Cliente"/> com o <paramref name="nome"/>.
        /// </summary>
        /// <param name="nome"> Nome do <see cref="Cliente"/></param>
        public Cliente(string nome)
        {
            Nome = nome;
        }
    }
}