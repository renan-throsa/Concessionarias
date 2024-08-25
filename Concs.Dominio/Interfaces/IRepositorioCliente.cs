using Concs.Dominio.Entidades;

namespace Concs.Dominio.Interfaces
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Task<bool> TuplaUnica(int id,string cpf);
    }
}
