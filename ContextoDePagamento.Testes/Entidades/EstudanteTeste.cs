using System;
using ContextoDePagamento.Dominio.Entidades;
using ContextoDePagamento.Dominio.Enums;
using ContextoDePagamento.Dominio.ObjetosDeValor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextoDePagamento.Testes.Entidades
{
    [TestClass]
    public class EstudanteTeste
    {
        private readonly Nome _name;
        private readonly Documento _document;
        private readonly Endereco _address;
        private readonly Email _email;
        private readonly Estudante _student;        

        public EstudanteTeste()
        {
            _name = new Nome("Bruce","Wayne");
            _document = new Documento("34489805799",ETipoDocumento.CPF);
            _email = new Email("brucewayne@wayneindustries.com");
            _address = new Endereco("Rua 1","1234",null,null,"Bairro Legal","Gotham City","Gotham City");
            _student = new Estudante(_name,_document,_email);            
        }

        //[TestMethod]
        // public void TestMethod1()
        // {
        //     Estudante estudante = new Estudante(new Nome("Gabriel","Simas"),null,new Email("gabrielsimas@gmail.com"));
        //     Assinatura assinatura = new Assinatura(DateTime.Now.AddDays(365));
            
        //     //Corrompendo o padrão para inserir assinaturas
        //     //Antes de Adicionar a lista de somente leitura IReadOnCollection
        //     //estudante.Assinaturas.Add(assinatura);

        //     //Corrompendo o padrão, conseguindo acessar a classe diretamente
        //     //estudante.Nome = "Gabriel";
        // }

        // public void AdicionarAssinatura()
        // {
        //     var nome = new Nome("Teste","Teste");
        //     string msg = string.Empty;            
        //     foreach(var not in nome.Notifications)
        //     {
        //         msg += not.Message;
        //     }
        // }

        [TestMethod]
        public void DeveRetornarErroQuandoTiverAssinaturaAtiva()
        {            
            var subscription = new Assinatura(null);
            var payment = new PagamentoPaypal(_email,"12345678",DateTime.Now,DateTime.Now.AddDays(5),10,10,"Wayne Industries ACME",_document,_address);
            subscription.AdicionarPagamento(payment);
            _student.AdicionaAssinatura(subscription);
            _student.AdicionaAssinatura(subscription);

            //Green(2)
            Assert.IsTrue(_student.Invalid);
            //Red (1)
            //Assert.Fail();
        }        

        [TestMethod]
        public void DeveRetornarErroQuandoAssinaturaNaoTiverPagamento()
        {                                    
            var subscription = new Assinatura(null);
            _student.AdicionaAssinatura(subscription);
            //Green(2)
            Assert.IsTrue(_student.Invalid);
            //Red (1)
            //Assert.Fail();
        }

        [TestMethod]
        public void DeveRetornarErroQuandoTiverAssinaturaAtivaSemPagamento()
        {
            var name = new Nome("Bruce","Wayne");
            var document = new Documento("34489805799",ETipoDocumento.CPF);
            var email = new Email("brucewayne@wayneindustries.com");
            var student = new Estudante(name,document,email);
            
            //Red (1)
            //Assert.Fail();
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoAdicionarAssinatura(){
            var subscription = new Assinatura(null);
            var payment = new PagamentoPaypal(_email,"12345678",DateTime.Now,DateTime.Now.AddDays(5),10,10,"Wayne Industries ACME",_document,_address);
            subscription.AdicionarPagamento(payment);
            _student.AdicionaAssinatura(subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}
