using Concs.Dados.Contexto;
using Concs.Dominio.Interfaces;

namespace Concs.Dados.Repositorios
{
    public class RepositorioConcessionária : Repositorio<Dominio.Entidades.Concessionaria>, IRepositorioConcessionária
    {
        public RepositorioConcessionária(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}
