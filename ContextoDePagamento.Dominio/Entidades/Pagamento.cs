using System;
using ContextoDePagamento.Dominio.ObjetosDeValor;
using ContextoDePagamento.Kernel.Entidades;
using Flunt.Validations;

namespace ContextoDePagamento.Dominio.Entidades
{
    public abstract class Pagamento: Entidade
    {
        public Pagamento(DateTime dataDePagamento, DateTime dataDeExpiracao, decimal total, decimal totalPago, string pagador, Documento documento, Endereco enderecoDeCobranca)
        {
            NumeroDoPagamento = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            DataDePagamento = dataDePagamento;
            DataDeExpiracao = dataDeExpiracao;
            Total = total;
            TotalPago = totalPago;
            Pagador = pagador;
            Documento = documento;
            EnderecoDeCobranca = enderecoDeCobranca;            

            //TODO: Adicionar validações para os outros parâmetros
            AddNotifications(new Contract()
                 .Requires()
                 .IsLowerOrEqualsThan(0,Total,"Pagamento.Total","O total não pode ser zero")
                 .IsGreaterOrEqualsThan(Total,TotalPago,"Pagamento.TotalPago","O valor pago é menor que o valor do Pagamento")
             );            
        }
        
        //TODO: Criar um Objeto de Valor para Número
        public string NumeroDoPagamento { get; private set; }
        //TODO: Criar um objeto de Valor para Tratar Datas
        public DateTime DataDePagamento { get; private set; }
        //TODO: Criar um objeto de Valor para Tratar Datas
        public DateTime DataDeExpiracao { get; private set; }
        //TODO: Criar um objeto de Valor para tratar valores monetários
        public decimal Total { get; private set; }
        //TODO: Criar um objeto de Valor para tratar valores monetários
        public decimal TotalPago { get; private set; }
        public string Pagador { get; private set; }
        public Documento Documento { get; private set; }
        public Endereco EnderecoDeCobranca { get; private set; }
    }        
    
}