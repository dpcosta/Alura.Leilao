namespace Alura.Leilao.Core
{
    public interface IEstrategiaAvaliacao
    {
        ResultadoLeilao Avalia(Leilao leilao);
    }
}
