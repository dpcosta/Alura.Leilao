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

            //leilão é criado com peça vinculada
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Rembrant");

            //aparecem interessados no leilão...
            var joao = new Interessado("João de Miranda", leilao);
            var pedro = new Interessado("Pedro Silveira", leilao);
            var malu = new Interessado("Malu Pereira", leilao);

            //leilão começa e os interessados dão lances...
            pedro.Oferece(1300);
            malu.Oferece(1350);
            joao.Oferece(1200);

            //leilão termina...
            var resultado = leilao.Termina();

            //...e conhecemos seu ganhador!
            Verifica(1350, resultado.MelhorLance.Valor);
            //Verifica(malu.Nome, leilao.MelhorLance.Cliente.Nome);

            Console.WriteLine("");
        }

        static void AvaliaLeilaoComLancesDoMesmoCliente()
        {
            Console.WriteLine(nameof(AvaliaLeilaoComLancesDoMesmoCliente));
            var leilao = new Alura.Leilao.Core.Leilao("Obra de Dalí");

            var joao = new Interessado("João de Miranda", leilao);

            joao.Oferece(900);
            joao.Oferece(1200);
            joao.Oferece(1300);
            joao.Oferece(1350);

            var resultado = leilao.Termina();

            Verifica(1350, resultado.MelhorLance.Valor);
            Console.WriteLine("");
        }

        static void Main()
        {
            AvaliaLeilaoComTresLances();
            AvaliaLeilaoComLancesDoMesmoCliente();
        }
    }
}
