using Concessionarias.Dados.Contexto;
using Concessionarias.Dominio.Interfaces;

namespace Concessionarias.Dados.Repositorios
{
    public class RepositorioConcessionária : Repositorio<Dominio.Entidades.Concessionaria>, IRepositorioConcessionária
    {
        public RepositorioConcessionária(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}
