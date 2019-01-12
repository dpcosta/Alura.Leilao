using System;

namespace Alura.Leilao.Core
{
    /// <summary>
    /// Valor proposto por um <see cref="Cliente"/> em um <see cref="Leilao"/>.
    /// </summary>
    public class Lance
    {
        public Interessado Cliente { get; }
        public double Valor { get; }

        /// <summary>
        /// Cria uma instância de lance com <paramref name="cliente"/> e <paramref name="valor"/>.
        /// </summary>
        /// <param name="cliente"> <see cref="Cliente"/> que propõe o lance.</param>
        /// <param name="valor"> Valor proposto para o lance. Deve ser maior que zero.</param>
        /// <exception cref="ArgumentException"> Exceção lançada se o valor for menor que zero.</exception>
        public Lance(Interessado cliente, double valor)
        {
            Cliente = cliente;
            if (valor < 0)
            {
                throw new ArgumentException("Lance inválido: valor deve ser maior que zero.");
            }
            Valor = valor;
        }
    }
}