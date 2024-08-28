using Concs.Dominio.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Concs.Negocio.Seviços
{

    public class ServiçoCacheamento : ICacheamento
    {
        private readonly IDistributedCache _distributedCache;
        private readonly DistributedCacheEntryOptions _options;

        public ServiçoCacheamento(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _options = new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600) };
        }

        public async Task DefinirAsync(string chave, string valor)
        {
            await _distributedCache.SetStringAsync(chave, valor, _options);
        }

        public async Task<string> ObtertAsync(string chave)
        {
            return await _distributedCache.GetStringAsync(chave);
        }

        //TODO remover apenas a ocrorrência que mudou
        public async Task RemoverAsync(string chave)
        {
            await _distributedCache.RemoveAsync(chave);
        }
    }
}
