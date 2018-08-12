using System;
using System.Collections.Generic;
using System.Linq;
using ContextoDePagamento.Kernel.Entidades;
using Flunt.Validations;

namespace ContextoDePagamento.Dominio.Entidades
{
    public class Assinatura: Entidade
    {
        private readonly IList<Pagamento> _pagamentos;
        public Assinatura(DateTime? dataDeExpiracao)
        {
            DataDeCriacao = DateTime.Now;
            DataDaUltimaAtualizacao = DateTime.Now;
            DataDeExpiracao = dataDeExpiracao;
            EstaAtiva = true;
            _pagamentos = new List<Pagamento>();
        }

        public DateTime DataDeCriacao { get; private set; }
        public DateTime DataDaUltimaAtualizacao { get; private set; }
        public DateTime? DataDeExpiracao { get; private set; }
        public Boolean EstaAtiva { get; private set; }
        public IReadOnlyCollection<Pagamento> Pagamentos { get {return _pagamentos.ToArray();} }

        public void AdicionarPagamento(Pagamento pagamento) {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now,pagamento.DataDePagamento,"Assinatura.Pagamentos","A data do Pagamento deve ser no futuro")
            );

            //Pode ser uma boa prática verificar se está válido
            //if (Valid) 
            _pagamentos.Add(pagamento);
        }
        public void Ativar()
        {
            EstaAtiva = true;
            DataDaUltimaAtualizacao = DateTime.Now;
        }

        public void Desativar(){
            EstaAtiva = false;
            DataDaUltimaAtualizacao = DateTime.Now;
        }
            
    }
}