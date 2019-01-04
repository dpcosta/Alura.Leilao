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
            if (Math.Abs(valorEsperado - valorRetornado) < 0.0001)
                Console.WriteLine(MSG_OK, valorEsperado);
            else
                Console.WriteLine(MSG_FALHA, valorEsperado, valorRetornado);
        }

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

            Verifica(1350, leiloeiro.MaiorLance);
            Verifica(1200, leiloeiro.MenorLance);

        }
    }
}
