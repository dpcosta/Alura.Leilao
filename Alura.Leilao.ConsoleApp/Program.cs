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
            leilao.Propoe(new Lance(malu, 1350));
            leilao.Propoe(new Lance(pedro, 1300));
            leilao.Propoe(new Lance(joao, 1200));

            var leiloeiro = new Avaliador(leilao);
            leiloeiro.Avalia();

            Console.WriteLine(leiloeiro.MaiorLance);
            Console.WriteLine(leiloeiro.MenorLance);
        }
    }
}
