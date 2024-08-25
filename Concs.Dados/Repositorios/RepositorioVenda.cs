using Concs.Dados.Contexto;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concs.Dados.Repositorios
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(SqlContext sqlContext) : base(sqlContext)
        {
        }

        public override async Task<Venda> GetByIdAsync(int id, bool comoRastreada = false)
        {
            var consulta = _currentSet.Where(x => x.Ativo);
            if (comoRastreada)
            {
                return await consulta.FirstAsync(x => x.Id == id);
            }

            return await _currentSet
                .AsNoTracking()
                .Include(x => x.Cliente)
                .Include(x => x.Veiculo).ThenInclude(x=> x.TipoVeiculo)
                .Include(x => x.Concessionaria)
                .FirstAsync(x => x.Id == id);
        }
    }
}
