using Concs.Dominio.Modelos;

namespace Concs.Dominio.Interfaces
{
    public interface IServiçoConcessionária
    {
        ModeloResultadoDaOperação FindAll();

        Task<ModeloResultadoDaOperação> FindById(int id);

        Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoConcessionária modelo);

        Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoConcessionária modelo);

        Task<ModeloResultadoDaOperação> Remove(int id);
    }
}
