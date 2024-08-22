using Concessionaria.Dominio.Modelos;

namespace Concessionaria.Dominio.Interfaces
{
    public interface IServiçoFabricante
    {
        Task<ModeloResultadoDaOperação> FindAll();

        Task<ModeloResultadoDaOperação> FindById(int id);

        Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoFabricante modelo);

        Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoFabricante modelo);

        Task<ModeloResultadoDaOperação> Remove(int id);
    }
}
