using Concs.Dominio.Entidades;

namespace Concs.Dominio.Interfaces
{
    public interface IRepositorioFabricante : IRepositorio<Fabricante>
    {
        Task<bool> NomeCadastrado(int id, string nome);
        Task<bool> NomeCadastrado(string nome);
    }
}
