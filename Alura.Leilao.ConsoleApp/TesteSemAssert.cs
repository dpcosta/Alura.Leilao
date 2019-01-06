using System;
using Alura.Leilao.Core;

namespace Alura.Leilao.ConsoleApp
{
    public class TesteSemAssert
    {
        static void Main()
        {
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");

            var joao = new Interessado("João de Miranda", leilao);
            var pedro = new Interessado("Pedro Silveira", leilao);
            var malu = new Interessado("Malu Pereira", leilao);

            pedro.Oferece(1300);
            malu.Oferece(1350);
            joao.Oferece(1200);

            var resultado = leilao.Termina();

            Console.WriteLine(resultado.MelhorLance.Valor);
        }
    }
}
