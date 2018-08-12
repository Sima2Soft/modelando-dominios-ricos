using System;
using ContextoDePagamento.Dominio.Enums;

namespace ContextoDePagamento.Dominio.Comandos
{
    public class ComandoCriarAssinaturaPayPal
    {
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string NumeroDoDocumento { get; set; }        
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string CodigoDaTransacao { get; set; }
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
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        //TODO: Criar um Objeto de Valor para o CEP
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        //TODO: Criar um Objeto de valor para o Estado
        public string Estado { get; set; }
    }
}