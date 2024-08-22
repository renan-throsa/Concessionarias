using Concessionaria.Dados.Contexto;
using Concessionaria.Dominio.Interfaces;

namespace Concessionaria.Dados.Repositorios
{
    public class RepositorioConcessionaria : Repositorio<Dominio.Entidades.Concessionaria>, IRepositorioConcessionaria
    {
        public RepositorioConcessionaria(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}
