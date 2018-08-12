using ContextoDePagamento.Dominio.Entidades;
using ContextoDePagamento.Dominio.Repositorios;

namespace ContextoDePagamento.Testes.Mocks
{
    public class EstudanteRepositorioFalso : IEstudanteRepositorio
    {
        public void CriarAssinatura(Estudante estudante)
        {
            throw new System.NotImplementedException();
        }

        public bool DocumentoExiste(string documento)
        {            
            if (documento == "99999999999")
                return true;

            return false;
        }

        public bool EmailExiste(string email)
        {
            if (email == "hello@balta.io")
                return true;

            return false;
        }
    }
}