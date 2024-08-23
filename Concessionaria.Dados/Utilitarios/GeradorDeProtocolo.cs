using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Concessionarias.Dados.Utilitarios
{
    internal class GeradorDeProtocolo: ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            return Guid.NewGuid().ToString().Substring(0, 20).ToUpper();
        }
    }
}
