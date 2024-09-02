using Concs.Dominio.Entidades;
namespace Concs.Dominio.Interfaces
{
    public interface IRepositorioVenda : IRepositorio<Venda>
    {
        Task<bool> vendaComVeiculo(int veiculoId);
        Task<bool> vendaComCliente(int clienteId);
        Task<bool> vendaComConcessionária(int concessionariaId);
    }
}
