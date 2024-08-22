using Concessionaria.Dados.Contexto;
using Concessionaria.Dominio.Entidades;
using Concessionaria.Dominio.Interfaces;

namespace Concessionaria.Dados.Repositorios
{
    public class RepositorioVeiculo : Repositorio<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculo(SqlContext sqlContext) : base(sqlContext)
        {
        }
    }
}
