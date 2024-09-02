using Concs.Dados.Contexto;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concs.Dados.Repositorios
{
    public class RepositorioVeiculo : Repositorio<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculo(SqlContext sqlContext) : base(sqlContext)
        {
        }

        public override async Task<Veiculo> GetByIdAsync(int id, bool comoRastreada = false)
        {
            var consulta = _currentSet.Where(x => x.Ativo);
            if (comoRastreada)
            {
                return await consulta.FirstOrDefaultAsync(x => x.Id == id);
            }

            return await _currentSet
                .AsNoTracking()
                .Include(x => x.Fabricante)
                .Include(x => x.TipoVeiculo)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> veiculoComFabricanteCom(int fabricanteId)
        {
            return await Query().Where(x => x.FabricanteId == fabricanteId).AnyAsync();
        }

    }
}
