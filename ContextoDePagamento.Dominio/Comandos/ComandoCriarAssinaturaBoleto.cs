using System;
using ContextoDePagamento.Dominio.Enums;
using ContextoDePagamento.Kernel.Comandos;
using Flunt.Validations;
using Flunt.Notifications;

namespace ContextoDePagamento.Dominio.Comandos
{
    public class ComandoCriarAssinaturaBoleto: Notifiable,IComando
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string NumeroDoDocumento { get; set; }        
        public string Endereco { get; set; }
        public string Email { get; set; }
        
        public string NumeroDoPagamento { get; set; }
        //TODO: Criar um objeto de Valor para Tratar Datas
        public DateTime DataDePagamento { get; set; }
        //TODO: Criar um objeto de Valor para Tratar Datas
        public DateTime DataDeExpiracao { get; set; }
        //TODO: Criar um objeto de Valor para tratar valores monetários
        public decimal Total { get; set; }
        //TODO: Criar um objeto de Valor para tratar valores monetários
        public decimal TotalPago { get; set; }
        public string Pagante { get; set; }
        public string DocumentoPagante { get; set; }        
        public ETipoDocumento TipoDocumentoPagante {get; set;}
        public string CodigoDeBarras { get; set; }

        //TODO: Criar um Objeto de Valor para tratar números grandes
        public string NossoNumero { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        //TODO: Criar um Objeto de Valor para o CEP
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        //TODO: Criar um Objeto de valor para o Estado
        public string Estado { get; set; }

        public void Validar()
        {
            //Adicionar validações sem ser Regras de Negócios
             AddNotifications(new Contract()
                .Requires()
                .HasMinLen(PrimeiroNome,3,"Nome.PrimeiroNome","Nome deve conter pelo menos 3 caracteres")
                .HasMinLen(Sobrenome,3,"Nome.Sobrenome","Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(PrimeiroNome,40,"Nome.PrimeiroNome","Nome deve conter até 40 caracteres")
                .HasMaxLen(Sobrenome,40,"Nome.PrimeiroNome","Nome deve conter até 40 caracteres")
            );
        }
    }
}