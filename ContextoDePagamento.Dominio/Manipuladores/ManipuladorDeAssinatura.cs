using ContextoDePagamento.Dominio.Comandos;
using ContextoDePagamento.Dominio.Entidades;
using ContextoDePagamento.Dominio.Enums;
using ContextoDePagamento.Dominio.ObjetosDeValor;
using ContextoDePagamento.Dominio.Repositorios;
using ContextoDePagamento.Dominio.Servicos;
using ContextoDePagamento.Kernel.Comandos;
using ContextoDePagamento.Kernel.Manipuladores;
using Flunt.Notifications;

namespace ContextoDePagamento.Dominio.Manipuladores
{
    //TODO: Adicionar também os manipuladores para o Pagamento via Paypal e Cartão de Crédito
    public class ManipuladorDeAssinatura :
        Notifiable,
        IManipulador<ComandoCriarAssinaturaBoleto>
    {
        private readonly IEstudanteRepositorio _repositorio;
        private readonly IEmailServico _servicoDeEmail;

        public ManipuladorDeAssinatura(IEstudanteRepositorio repositorio, IEmailServico servicoDeEmail)
        {
            _repositorio = repositorio;    
            _servicoDeEmail = servicoDeEmail;
        }

        public IResultadoComando Manipula(ComandoCriarAssinaturaBoleto comando)
        {
            // Fail fast Validations
            comando.Validar();
            if(comando.Invalid)
            {
                AddNotifications(comando);
                return new ResultadoComando(false,"Não foi possivel realizar sua assinatura");
            }

            // Verificar se o Documento já está cadastrado
            if(_repositorio.DocumentoExiste(comando.NumeroDoDocumento))
                AddNotification("Documento","Este CPF já está em uso");            

            // Verificar se E-mail já está cadastrado
            if(_repositorio.EmailExiste(comando.Email))
                AddNotification("Email","Este E-mail já está em uso");

            // Gerar os VOs
            var name = new Nome(comando.PrimeiroNome,comando.Sobrenome);
            var document = new Documento(comando.NumeroDoDocumento,ETipoDocumento.CPF);
            var email = new Email(comando.Email);
            var address = new Endereco(comando.Rua,comando.Numero,null,null,comando.Bairro,comando.Cidade,comando.Estado);            

            // Gerar as Entidades
            var student = new Estudante(name,document,email);                
            var subscription = new Assinatura(null);
            var pagamento = new PagamentoBoleto(comando.CodigoDeBarras,comando.NossoNumero,new Email(comando.Email),comando.DataDePagamento,comando.DataDeExpiracao,comando.Total,comando.TotalPago,comando.Pagante,new Documento(comando.NumeroDoDocumento, ETipoDocumento.CPF),null);

            // Relacionamentos
            subscription.AdicionarPagamento(pagamento);
            student.AdicionaAssinatura(subscription);

            //Agrupar as Validações
            AddNotifications(name,document,email,address,student,subscription,pagamento);

            // Checar as notificações
            if (Invalid)
                return new ResultadoComando(false,"Não foi possível realizar sua assinatura");

            // Salvar as Informações
            _repositorio.CriarAssinatura(student);

            // Enviar E-mail de boas vindas
            _servicoDeEmail.Enviar(student.Nome.ToString(),student.Email.Endereco,"Bem vindo à Simasoft Holdings","Seja bem vindo! Sua assinatura foi criada");

            //Retornar informações
            return new ResultadoComando(true,"Cadastro efetuado com sucesso!");
        }
    }
}