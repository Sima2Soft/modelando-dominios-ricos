using ContextoDePagamento.Dominio.Enums;
using ContextoDePagamento.Kernel.ObjetosDeValor;
using Flunt.Validations;

namespace ContextoDePagamento.Dominio.ObjetosDeValor
{
    public class Documento: ObjetoDeValor
    {
        public Documento(string numero,ETipoDocumento tipo)
        {
            Numero = numero;
            Tipo = tipo;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validar(),"Documento.Numero","Documento inválido")
            );
        }

        public string Numero { get; private set; }
        public ETipoDocumento Tipo { get; private set; }

        private bool Validar()
        {
            switch(Tipo){
                case ETipoDocumento.CNPJ:
                if (Numero.Length == 14)
                    return true;
                //TODO:Validação do CNPJ aqui                
                break;
                case ETipoDocumento.CPF:
                if (Numero.Length == 11)
                    return true;
                //TODO:Validação do CNPJ aqui
                break;
            }   
            return false;
        }
    }
}