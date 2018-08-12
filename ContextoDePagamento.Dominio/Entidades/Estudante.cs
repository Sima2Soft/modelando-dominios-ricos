using System.Collections.Generic;
using System.Linq;
using ContextoDePagamento.Dominio.ObjetosDeValor;
using ContextoDePagamento.Kernel.Entidades;
using Flunt.Validations;

namespace ContextoDePagamento.Dominio.Entidades{
    /// <summary>
    /// Classe que respeita os seguintes padrões SOLID:
    /// SRP => Single Responsibility Principal ou Princípio da responsabilidade única => Só tem uma responsabilidade
    /// que é domínio estudante, só regras para estudante
    /// OCP => Open Close Principal, Princípio do Aberto e fechado => A Classe pode ser estendida,
    /// mas não pode ser modificada, pois as propriedades estão marcadas como 'Private Set'
    /// </summary>
    public class Estudante: Entidade
    {

        //Este método é criado para adicionar assinaturas internamente
        //pois externamente não é possível, pois a lista está como somente leitura
        private IList<Assinatura> _assinaturas;

        public Estudante(Nome nome, Documento documento, Email email)
        {
            Nome = nome;            
            Documento = documento;
            Email = email;  
            //Torna-se uma ligação por composição
            _assinaturas = new List<Assinatura>(); 

            AddNotifications(nome,documento,email);                     
        }

        public Nome Nome {get; private set;}        
        public Documento Documento { get; private set; }
        public Email Email { get; private set; }
    
        public Endereco EnderecoDeEntrega { get; private set; }
        public IReadOnlyCollection<Assinatura> Assinaturas { get { return _assinaturas.ToArray(); } }

        public void AdicionaAssinatura(Assinatura assinatura)
        {
            // Se já tiver uma assinatura ativa, cancela

            // Cancela todas as outras assinaturas, e coloca esta
            // como principal
            // foreach(Assinatura assina in Assinaturas){
            //     assina.Desativar();
            // }

            // _assinaturas.Add(assinatura);

            var temAssinaturaAtiva = false;
            foreach(var assina in _assinaturas)
            {
                if(assina.EstaAtiva)
                    temAssinaturaAtiva = true;                 
            }

            AddNotifications(new Contract()
                 .Requires()
                 .IsFalse(temAssinaturaAtiva,"Estudante.Assinaturas","Você já tem uma assinatura ativa")
                 .AreEquals(0,assinatura.Pagamentos.Count,"Estudante.Assinaturas.Pagamento","Esta assinatura não possui pagamentos")
             );

            if (Valid)
                _assinaturas.Add(assinatura);
            //Alternativa
            //if(temAssinaturaAtiva)
            //    AddNotification("Estudante.Assinaturas","Você já tem uma assinatura ativa");
        }
    }
}