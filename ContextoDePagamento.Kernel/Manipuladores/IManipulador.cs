using ContextoDePagamento.Kernel.Comandos;

namespace ContextoDePagamento.Kernel.Manipuladores
{
    public interface IManipulador<T> where T: IComando
    {
        IResultadoComando Manipula(T comando);
    }
}