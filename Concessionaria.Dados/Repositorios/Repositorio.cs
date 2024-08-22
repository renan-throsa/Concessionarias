using Concessionaria.Dados.Contexto;
using Concessionaria.Dominio.Entidades;
using Concessionaria.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Concessionaria.Dados.Repositorios
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

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, TEntity>> projection)
            => await _currentSet.AsNoTracking().Select(projection).ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int id)
            => await _currentSet.FindAsync(id);


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
