using ContextoDePagamento.Kernel.ObjetosDeValor;
using Flunt.Validations;

namespace ContextoDePagamento.Dominio.ObjetosDeValor
{
    public class Email: ObjetoDeValor
    {
        public Email(string endereco) {
            Endereco = endereco;
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(endereco,"Email.Endereco","E-mail inválido")
            );
        } 

        public string Endereco { get; private set; }
    }
}