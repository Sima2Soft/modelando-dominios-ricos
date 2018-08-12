using System;
using ContextoDePagamento.Dominio.ObjetosDeValor;

namespace ContextoDePagamento.Dominio.Entidades
{
    public class PagamentoPaypal: Pagamento
    {
        public PagamentoPaypal(Email email,
        string codigoDaTransacao,
        DateTime dataDePagamento,
        DateTime dataDeExpiracao,
        decimal total,
        decimal totalPago,
        string pagador,
        Documento documento,
        Endereco enderecoDeCobranca):base(dataDePagamento,dataDeExpiracao,total,totalPago,pagador,documento,enderecoDeCobranca)
        {
            Email = email;
            CodigoDaTransacao = codigoDaTransacao;
        }

        public Email Email { get; private set; }
        public string CodigoDaTransacao { get; private set; }
    }
}