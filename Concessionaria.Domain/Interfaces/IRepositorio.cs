using Concessionaria.Dominio.Entidades;
using System.Linq.Expressions;

namespace Concessionaria.Dominio.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : EntidadeBase
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, TEntity>> projecao);

        Task<TEntity> GetByIdAsync(int id);

        Task InsertAllAsync(IEnumerable<TEntity> entities);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task UpdateAllAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        Task DeleteAllAsync(IEnumerable<TEntity> entities);

        Task<int> SaveChangesAsync();

        IQueryable<TEntity> Query();

    }
}
