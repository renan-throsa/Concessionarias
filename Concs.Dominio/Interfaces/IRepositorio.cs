using Concs.Dominio.Entidades;

namespace Concs.Dominio.Interfaces
{
    public interface IRepositorio<TEntity> where TEntity : EntidadeBase
    {       

        Task<TEntity> GetByIdAsync(int id, bool comoRastreada = false);

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
