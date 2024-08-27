namespace Concs.Dominio.Interfaces
{
    public interface ICacheamento
    {
        Task DefinirAsync(string chave, string valor);
        Task<string> ObtertAsync(string chave);
    }
}
