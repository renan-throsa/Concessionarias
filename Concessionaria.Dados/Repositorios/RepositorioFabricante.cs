using Concessionarias.Dados.Contexto;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Interfaces;

namespace Concessionarias.Dados.Repositorios
{
    public class RepositorioFabricante : Repositorio<Fabricante>, IRepositorioFabricante
    {
        public RepositorioFabricante(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}
