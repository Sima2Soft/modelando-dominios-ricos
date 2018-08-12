using ContextoDePagamento.Dominio.Entidades;
using ContextoDePagamento.Dominio.Repositorios;
using ContextoDePagamento.Dominio.Servicos;

namespace ContextoDePagamento.Testes.Mocks
{
    public class EmailServicoFalse : IEmailServico
    {
        public void Enviar(string para, string email, string assunto, string corpo)
        {
            
        }
    }
}