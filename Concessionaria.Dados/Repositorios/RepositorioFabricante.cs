using Concessionaria.Dados.Contexto;
using Concessionaria.Dominio.Entidades;
using Concessionaria.Dominio.Interfaces;

namespace Concessionaria.Dados.Repositorios
{
    public class RepositorioFabricante : Repositorio<Fabricante>, IRepositorioFabricante
    {
        public RepositorioFabricante(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}
