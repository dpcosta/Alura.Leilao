using System;
using Alura.Leilao.Core;

namespace Alura.Leilao.ConsoleApp
{
    class Program
    {
        private const string MSG_OK = "Valor esperado ({0}) confirmado!";
        private const string MSG_FALHA = "Erro! Valor esperado: {0}, valor retornado: {1}";

        static void Verifica(double valorEsperado, double valorRetornado)
        {
            var corAnterior = Console.ForegroundColor;
            if (Math.Abs(valorEsperado - valorRetornado) < 0.0001)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(MSG_OK, valorEsperado);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(MSG_FALHA, valorEsperado, valorRetornado);
            }
            Console.ForegroundColor = corAnterior;
        }

        static void AvaliaLeilaoComTresLances()
        {
            Console.WriteLine(nameof(AvaliaLeilaoComTresLances));
            var joao = new Cliente("João de Miranda");
            var pedro = new Cliente("Pedro Silveira");
            var malu = new Cliente("Malu Pereira");
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");
            leilao.Propoe(new Lance(pedro, 1300));
            leilao.Propoe(new Lance(malu, 1350));
            leilao.Propoe(new Lance(joao, 1200));

            var leiloeiro = new Avaliador(leilao);
            leiloeiro.Avalia();

            Verifica(1350, leiloeiro.MaiorLance);
            Verifica(900, leiloeiro.MenorLance);
            Console.WriteLine("");
        }

        static void AvaliaLeilaoComLancesDoMesmoCliente()
        {
            Console.WriteLine(nameof(AvaliaLeilaoComLancesDoMesmoCliente));
            var joao = new Cliente("João de Miranda");
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Dalí");
            leilao.Propoe(new Lance(joao, 900));
            leilao.Propoe(new Lance(joao, 1200));
            leilao.Propoe(new Lance(joao, 1300));
            leilao.Propoe(new Lance(joao, 1350));

            var leiloeiro = new Avaliador(leilao);
            leiloeiro.Avalia();

            Verifica(1350, leiloeiro.MaiorLance);
            Verifica(900, leiloeiro.MenorLance);
            Console.WriteLine("");
        }

        static void Main()
        {
            AvaliaLeilaoComTresLances();
            AvaliaLeilaoComLancesDoMesmoCliente();
        }
    }
}
