using Concs.Dominio.Modelos;

namespace Concs.Dominio.Interfaces
{
    public interface IServiçoFabricante
    {
        ModeloResultadoDaOperação FindAll();

        Task<ModeloResultadoDaOperação> FindById(int id);

        Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoFabricante modelo);

        Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoFabricante modelo);

        Task<ModeloResultadoDaOperação> Remove(int id);
    }
}
