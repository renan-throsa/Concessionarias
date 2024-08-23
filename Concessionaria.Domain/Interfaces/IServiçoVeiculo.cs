using Concessionarias.Dominio.Modelos;

namespace Concessionarias.Dominio.Interfaces
{
    public interface IServiçoVeiculo
    {
        ModeloResultadoDaOperação FindAll();

        Task<ModeloResultadoDaOperação> FindById(int id);

        Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoVeiculo modelo);

        Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoVeiculo modelo);

        Task<ModeloResultadoDaOperação> Remove(int id);
    }
}
