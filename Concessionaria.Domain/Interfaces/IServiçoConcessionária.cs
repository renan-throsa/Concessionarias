using Concessionaria.Dominio.Modelos;

namespace Concessionaria.Dominio.Interfaces
{
    public interface IServiçoConcessionária
    {
        Task<ModeloResultadoDaOperação> FindAll();

        Task<ModeloResultadoDaOperação> FindById(int id);

        Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoConcessionária modelo);

        Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoConcessionária modelo);

        Task<ModeloResultadoDaOperação> Remove(int id);
    }
}
