using Concessionaria.Dominio.Modelos;

namespace Concessionaria.Dominio.Interfaces
{
    public interface IServiçoVeivulo
    {
        Task<ModeloResultadoDaOperação> FindAll();

        Task<ModeloResultadoDaOperação> FindById(int id);

        Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoVeiculo modelo);

        Task<ModeloResultadoDaOperação> Update(ModeloAtualizaçãoVeivulo modelo);

        Task<ModeloResultadoDaOperação> Remove(int id);
    }
}
