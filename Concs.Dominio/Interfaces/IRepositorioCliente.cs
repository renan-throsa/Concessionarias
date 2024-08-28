using Concs.Dominio.Entidades;

namespace Concs.Dominio.Interfaces
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        Task<bool> CPFCadastrado(int id,string cpf);
        Task<bool> CPFCadastrado(string cpf);
    }
}
