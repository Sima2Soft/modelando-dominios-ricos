using ContextoDePagamento.Kernel.ObjetosDeValor;
using Flunt.Validations;

namespace ContextoDePagamento.Dominio.ObjetosDeValor
{
    public class Nome: ObjetoDeValor
    {
        public Nome(string nome, string sobrenome)
        {
            PrimeiroNome = nome;
            Sobrenome = sobrenome;
            
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PrimeiroNome,3,"Nome.PrimeiroNome","Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(Sobrenome,3,"Nome.Sobrenome","Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(PrimeiroNome,40,"Nome.PrimeiroNome","Nome deve conter até 40 caracteres")
                .HasMaxLen(Sobrenome,40,"Nome.PrimeiroNome","Nome deve conter até 40 caracteres")
            );
        }

        public string PrimeiroNome { get; private set; }
        public string Sobrenome { get; private set; }

        public override string ToString()
        {
            return $"{PrimeiroNome}{Sobrenome}";
        }


    }
}