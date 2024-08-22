using Concessionaria.Dados.Contexto;
using Concessionaria.Dominio.Entidades;
using Concessionaria.Dominio.Interfaces;

namespace Concessionaria.Dados.Repositorios
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}
