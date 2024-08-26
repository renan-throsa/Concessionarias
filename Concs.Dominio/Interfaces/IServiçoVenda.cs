using Concs.Dominio.Modelos;

namespace Concs.Dominio.Interfaces
{
    public interface IServiçoVenda
    {
        ModeloResultadoDaOperação FindAll();

        Task<ModeloResultadoDaOperação> FindById(int id);

        Task<ModeloResultadoDaOperação> Insert(ModeloInserçãoVenda modelo);       

        Task<ModeloResultadoDaOperação> Remove(int id);

        Task<ModeloResultadoDaOperação> Relatorios(int mes, int ano);
    }
}
