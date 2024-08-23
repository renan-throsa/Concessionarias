using Concessionarias.Dominio.Modelos;

namespace Concessionarias.Dominio.Interfaces
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
