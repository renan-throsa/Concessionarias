using Concs.Dominio.Entidades;

namespace Concs.Dominio.Interfaces
{
    public interface IRepositorioConcessionária : IRepositorio<Concessionaria>
    {
        Task<bool> NomeCadastrado(int id, string nome);
        Task<bool> NomeCadastrado(string nome);
    }
}
