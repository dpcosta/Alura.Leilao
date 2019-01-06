using Xunit;

namespace Alura.Leilao.Tests
{
    class Calculadora
    {
        public int Soma(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    public class CalculadoraTestes
    {
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        [InlineData(0,1,1)]
        public void TestaSomaParaDoisNumeros(int num1, int num2, int esperado)
        {
            var calc = new Calculadora();
            var resultado = calc.Soma(num1, num2);
            Assert.Equal(esperado, resultado);
        }
    }
}
