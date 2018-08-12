using System;
using ContextoDePagamento.Dominio.Entidades;
using ContextoDePagamento.Dominio.Enums;
using ContextoDePagamento.Dominio.ObjetosDeValor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextoDePagamento.Testes.ObjetosDeValor
{
    [TestClass]
    public class DocumentoTeste
    {
        [TestMethod]
        public void DeveRetornarErroQuandoOCNPJForInvalido()
        {
            //Green(2)
            var doc = new Documento("123",ETipoDocumento.CNPJ);
            Assert.IsTrue(doc.Invalid);

            //Red (1)
            //Assert.Fail();
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoOCNPJForValido()
        {
            //Green(2)
            var doc = new Documento("44447278000187",ETipoDocumento.CNPJ);
            Assert.IsTrue(doc.Valid);

            //Red (1)
            //Assert.Fail();
        }

        [TestMethod]
        public void DeveRetornarErroQuandoOCPFForInvalido()
        {
            //Green (2)
            var doc = new Documento("123",ETipoDocumento.CPF);
            Assert.IsTrue(doc.Invalid);
            //Red (1)
            //Assert.Fail();
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("34489805799")]
        [DataRow("47664002753")]
        [DataRow("26680587751")]
        public void DeveRetornarSucessoQuandoOCPFForValido(string cpf)
        {
            //Green (2)
            var doc = new Documento(cpf,ETipoDocumento.CPF);
            Assert.IsTrue(doc.Valid);
            //Red (1)
            //Assert.Fail();
        }
    }
}
