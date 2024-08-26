using Concs.Dados.Contexto;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concs.Dados.Repositorios
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        protected readonly DbSet<TEntity> _currentSet;
        private readonly SqlContext _context;

        protected Repositorio(SqlContext sqlContext)
        {
            _context = sqlContext;
            _currentSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id, bool comoRastreada = false)
        {
            var consulta = _currentSet.Where(x => x.Ativo);
            if (comoRastreada)
            {
                return await consulta.FirstAsync(x => x.Id == id);
            }

            return await _currentSet.AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public virtual async Task InsertAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.AddRange(entities);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            _currentSet.Add(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _currentSet.Update(entity);
        }

        public virtual async Task UpdateAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.UpdateRange(entities);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _currentSet.Remove(entity);
        }

        public virtual async Task DeleteAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.RemoveRange(entities);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public IQueryable<TEntity> Query()
        {
            return _currentSet.AsNoTracking().Where(x => x.Ativo);
        }
        

        public async Task<Relatorio> Resports(int mes, int ano)
        {
            var totalVendas = _context.Vendas.Where(x => x.DataVenda.Month == mes && x.DataVenda.Year == ano).Sum(x => x.PrecoVenda);


            var VendasPorTipoDeveiculo = await (from venda in _context.Vendas
                                                join veiculo in _context.Veiculos on venda.VeiculoId equals veiculo.Id
                                                join tipoVeiculo in _context.TiposVeiculos on veiculo.TipoVeiculoId equals tipoVeiculo.Id
                                                where venda.DataVenda.Month == mes && venda.DataVenda.Year == ano
                                                group venda.PrecoVenda by tipoVeiculo.Tipo into grupo
                                                select new Dado
                                                {
                                                    Chave = grupo.Key,
                                                    Valor = grupo.Sum()
                                                }).ToListAsync();

            var VendasPorFabricante = await (from venda in _context.Vendas
                                             join veiculo in _context.Veiculos on venda.VeiculoId equals veiculo.Id
                                             join fabricante in _context.Fabricantes on veiculo.FabricanteId equals fabricante.Id
                                             where venda.DataVenda.Month == mes && venda.DataVenda.Year == ano
                                             group venda.PrecoVenda by fabricante.Nome into grupo
                                             select new Dado
                                             {
                                                 Chave = grupo.Key,
                                                 Valor = grupo.Sum()
                                             }).ToListAsync();

            var desempenhoPorConcessionaria = await (from venda in _context.Vendas
                                                     join concessionaria in _context.Concessionarias on venda.ConcessionariaId equals concessionaria.Id
                                                     where venda.DataVenda.Month == mes && venda.DataVenda.Year == ano
                                                     group venda.PrecoVenda by concessionaria.Nome into grupo
                                                     select new Dado
                                                     {
                                                         Chave = grupo.Key,
                                                         Valor = grupo.Sum()
                                                     }).ToListAsync();

            return new Relatorio() { Mes = mes, Ano = ano, TotalVendas = totalVendas, VendasPorTipoDeveiculo = VendasPorTipoDeveiculo, VendasPorFabricante = VendasPorFabricante, DesempenhoPorConcessionaria = desempenhoPorConcessionaria };
        }
    }
}
