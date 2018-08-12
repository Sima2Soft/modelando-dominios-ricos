using System;
using System.Linq.Expressions;
using ContextoDePagamento.Dominio.Entidades;

namespace ContextoDePagamento.Dominio.Consultas
{
    public static class EstudanteConsulta
    {
        //TODO: Pode gerar cada query para cada método do Modelo de Domínio e colocar dentro da camada de repositorio
        public static Expression<Func<Estudante,bool>> ConsultaInformacoesDoEstudante(string documento)
        {
            return x => x.Documento.Numero == documento;
        }
    }
}