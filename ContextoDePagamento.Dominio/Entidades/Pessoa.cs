namespace ContextoDePagamento.Dominio.Entidades
{
    public abstract class Pessoa
    {

    }

    public class Fisica: Pessoa
    {
        public string Cpf { get; set; }
    }

    public class Juridica: Pessoa
    {
        public string Cnpj { get; set; }
    }
}