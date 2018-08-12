namespace ContextoDePagamento.Dominio.Servicos
{
    public interface IEmailServico
    {
        void Enviar(string para, string email, string assunto, string corpo);
    }
}