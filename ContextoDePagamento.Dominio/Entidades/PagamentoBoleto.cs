using System;
using ContextoDePagamento.Dominio.ObjetosDeValor;

namespace ContextoDePagamento.Dominio.Entidades
{
    public class PagamentoBoleto: Pagamento
    {
        public PagamentoBoleto(
            string codigoDeBarras,
            string nossoNumero,
            Email email,
            DateTime dataDePagamento,
            DateTime dataDeExpiracao,
            decimal total,
            decimal totalPago,
            string pagador,
            Documento documento,
            Endereco enderecoDeCobranca
            ):base(dataDePagamento,dataDeExpiracao,total,totalPago,pagador,documento,enderecoDeCobranca)
        {
            CodigoDeBarras = codigoDeBarras;
            NossoNumero = nossoNumero;
            Email = email;

            //TODO: Adicionar Validação para os campos do construtor
        }

        //TODO: Criar um Objeto de Valor para o Código de Barras
        public string CodigoDeBarras { get; private set; }

        //TODO: Criar um Objeto de Valor para tratar números grandes
        public string NossoNumero { get; private set; }
        public Email Email { get; private set; }
    }
}