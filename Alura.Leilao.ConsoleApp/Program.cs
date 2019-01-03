using System;
using Alura.Leilao.Core;

namespace Alura.Leilao.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var joao = new Cliente("João de Miranda");
            var pedro = new Cliente("Pedro Silveira");
            var malu = new Cliente("Malu Pereira");
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");
            leilao.Propoe(new Lance(joao, 1200));
            leilao.Propoe(new Lance(pedro, 1300));
            leilao.Propoe(new Lance(malu, 1350));

            var leiloeiro = new Avaliador(leilao);
            leiloeiro.Avalia();

            if (Math.Abs(1350 - leiloeiro.MaiorLance) < 0.0001)
                Console.WriteLine("Maior lance verificado");
            else
                Console.Error.WriteLine("Maior lance diferente de 1350!");

            if (Math.Abs(1200 - leiloeiro.MenorLance) < 0.0001)
                Console.WriteLine("Menor lance verificado");
            else
                Console.Error.WriteLine("Menor lance diferente de 1200!");

        }
    }
}
