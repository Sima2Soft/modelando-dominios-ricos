using System.Collections.Generic;
using System.Linq;
using ContextoDePagamento.Dominio.Consultas;
using ContextoDePagamento.Dominio.Entidades;
using ContextoDePagamento.Dominio.Enums;
using ContextoDePagamento.Dominio.ObjetosDeValor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextoDePagamento.Testes.Consultas
{
    [TestClass]
    public class EstudanteConsultaTeste
    {
        private IList<Estudante> _estudantes;

        public EstudanteConsultaTeste()
        {
            for(int i = 0; i <= 10;i++)
            {
                _estudantes.Add(new Estudante(
                    new Nome("Aluno",i.ToString()),
                    new Documento("1111111111" + i.ToString(),ETipoDocumento.CPF),
                    new Email(i.ToString() + "@balta.io")
                ));
            }
        }

        [TestMethod]
        public void DeveRetornarNullQuandoDocumentoNaoExistir()
        {
            var exp = EstudanteConsulta.ConsultaInformacoesDoEstudante("12345678911");
            var studn = _estudantes.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null,studn);
        }

        [TestMethod]
        public void DeveRetornarEstudanteQuandoDocumentoExistir()
        {
            var exp = EstudanteConsulta.ConsultaInformacoesDoEstudante("11111111111");
            var studn = _estudantes.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null,studn);
        }
    }
}