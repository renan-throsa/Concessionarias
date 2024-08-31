using Concs.Dominio.Entidades;

namespace Concs.Dominio.Interfaces
{
    public interface IRepositorioVeiculo : IRepositorio<Veiculo>
    {
        Task<bool> veiculoComFabricanteCom(int fabricanteId);
    }
}
