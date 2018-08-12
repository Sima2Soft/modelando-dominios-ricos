using System;
using ContextoDePagamento.Dominio.ObjetosDeValor;

namespace ContextoDePagamento.Dominio.Entidades
{
    //TODO: Adicionar as bandeiras do Cartão e suas respectivas Regras    
    public class PagamentoCartaoDeCredito: Pagamento
    {
        public PagamentoCartaoDeCredito(
            string nomeProprietario,
            string numeroCartao,
            string numeroDaUltimaTransacao,
            DateTime dataDePagamento,
            DateTime dataDeExpiracao,
            decimal total,
            decimal totalPago,
            string pagador,
            Documento documento,
            Endereco enderecoDeCobranca
            ):base(dataDePagamento, dataDeExpiracao, total, totalPago, pagador,documento,enderecoDeCobranca)
        {
            NomeProprietario = nomeProprietario;
            NumeroCartao = numeroCartao;
            NumeroDaUltimaTransacao = numeroDaUltimaTransacao;
        }

        //REGRA DE NEGÓCIO: Se o endereço de cobrança do aluno for diferente do endereço de entrega, negar o processamento
        public string NomeProprietario { get; private set; }

        //Apenas os 4 ultios digitos do cartão
        public string NumeroCartao { get; private set; }
        public string NumeroDaUltimaTransacao { get; private set; }
    }
}