using ContextoDePagamento.Kernel.ObjetosDeValor;
using Flunt.Validations;

namespace ContextoDePagamento.Dominio.ObjetosDeValor
{
    public class Endereco: ObjetoDeValor
    {
        public Endereco(string rua, string numero, string complemento, string cep, string bairro, string cidade, string estado)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;

            //TODO: Adicionar a validação para todos os campos
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Rua,3,"Endereco.Rua","Nome da Rua deve conter pelo menos 3 caracteres")              
            );
        }

        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        //TODO: Criar um Objeto de Valor para o CEP
        public string Cep { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }

        //TODO: Criar um Objeto de valor para o Estado
        public string Estado { get; private set; }
    }
}
