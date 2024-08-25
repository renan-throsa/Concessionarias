using Concs.Dados.Contexto;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;

namespace Concs.Dados.Repositorios
{
    public class RepositorioFabricante : Repositorio<Fabricante>, IRepositorioFabricante
    {
        public RepositorioFabricante(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}
