using Concessionarias.Dados.Contexto;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Concessionarias.Dados.Repositorios
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
        

    }
}
