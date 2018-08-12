using System;
using ContextoDePagamento.Dominio.Comandos;
using ContextoDePagamento.Dominio.Enums;
using ContextoDePagamento.Dominio.Manipuladores;
using ContextoDePagamento.Testes.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextoDePagamento.Testes
{
    [TestClass]
    public class ManipuladorDeAssinaturaTeste
    {
        [TestMethod]
        public void DeveRetornarErroQuandoNomeForInvalido()
        {
            var manipulador = new ManipuladorDeAssinatura(new EstudanteRepositorioFalso(), new EmailServicoFalse());
            var comando = new ComandoCriarAssinaturaBoleto();

            comando.PrimeiroNome="Bruce";
            comando.Sobrenome="Wayne";
            comando.NumeroDoDocumento="99999999999";        
            comando.Endereco="hello@balta.io";
            comando.Email="";            
            comando.NumeroDoPagamento="123121";        
            comando.DataDePagamento=DateTime.Now;            
            comando.DataDeExpiracao=DateTime.Now.AddMonths(1);            
            comando.Total=60;            
            comando.TotalPago=60;
            comando.Pagante= "Wayne Industries";
            comando.DocumentoPagante="12345678911";        
            comando.TipoDocumentoPagante = ETipoDocumento.CPF;
            comando.CodigoDeBarras="123456789";            
            comando.NossoNumero="123456789";
            comando.Rua="Aaaafaf";
            comando.Numero="FAFAEFEF";
            comando.Complemento="hrthrh";
            comando.Cep="123445";
            comando.Bairro="sgsg";
            comando.Cidade="Gotham City";            
            comando.Estado="GC";

            manipulador.Manipula(comando);
            Assert.AreEqual(false, manipulador.Valid);
            
        }
    }
}