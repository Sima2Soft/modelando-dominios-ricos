using ContextoDePagamento.Dominio.Comandos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContextoDePagamento.Testes
{
    [TestClass]
    public class ComandoCriarAssinaturaBoletoTeste
    {
        [TestMethod]
        public void DeveRetornarErroQuandoNomeForInvalido()
        {
            var comando = new ComandoCriarAssinaturaBoleto();
            comando.PrimeiroNome = "";

            comando.Validar();
        }
    }
}