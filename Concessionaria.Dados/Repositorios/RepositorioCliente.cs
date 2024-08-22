using Concessionaria.Dados.Contexto;
using Concessionaria.Dominio.Entidades;
using Concessionaria.Dominio.Interfaces;

namespace Concessionaria.Dados.Repositorios
{
    public sealed class RepositorioCliente : Repositorio<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(SqlContext sqlContext) : base(sqlContext) { }
    }
}
