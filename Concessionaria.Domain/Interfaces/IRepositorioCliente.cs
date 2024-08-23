using Concessionarias.Dominio.Entidades;

namespace Concessionarias.Dominio.Interfaces
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Task<bool> TuplaUnica(int id,string cpf);
    }
}
