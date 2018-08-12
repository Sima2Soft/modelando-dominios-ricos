using ContextoDePagamento.Dominio.Entidades;

namespace ContextoDePagamento.Dominio.Repositorios
{
    //TODO: Criar a camada de infraestrutura
    public interface IEstudanteRepositorio
    {
        bool DocumentoExiste(string documento);
        bool EmailExiste(string email);
        void CriarAssinatura(Estudante estudante);
    }
}