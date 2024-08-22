using Concessionaria.Dados.Utilitarios;
using Concessionaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concessionaria.Dados.Configs
{
    internal sealed class VendaConfig : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.Property(x => x.DataVenda).HasColumnType("datetime");
            builder.Property(x => x.ProtocoloVenda).HasMaxLength(20).HasValueGenerator((x, y) => new GeradorDeProtocolo());

            builder.HasOne(x => x.Cliente);
            builder.HasOne(x => x.Veiculo);
            builder.HasOne(x => x.Concessionaria);

            List<Venda> vendas = new List<Venda>
        {
            new Venda
            {
                VendaId = 1,
                VeiculoId = 1,
                ConcessionariaId = 1,
                ClienteId = 1,
                DataVenda = new DateTime(2024, 8, 22),
                PrecoVenda = 50000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0,20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                VendaId = 2,
                VeiculoId = 2,
                ConcessionariaId = 2,
                ClienteId = 2,
                DataVenda = new DateTime(2024, 8, 23),
                PrecoVenda = 45000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0,20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                VendaId = 3,
                VeiculoId = 3,
                ConcessionariaId = 3,
                ClienteId = 3,
                DataVenda = new DateTime(2024, 8, 24),
                PrecoVenda = 55000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0,20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                VendaId = 4,
                VeiculoId = 4,
                ConcessionariaId = 4,
                ClienteId = 4,
                DataVenda = new DateTime(2024, 8, 25),
                PrecoVenda = 48000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                VendaId = 5,
                VeiculoId = 5,
                ConcessionariaId = 5,
                ClienteId = 5,
                DataVenda = new DateTime(2024, 8, 26),
                PrecoVenda = 52000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                VendaId = 6,
                VeiculoId = 6,
                ConcessionariaId = 6,
                ClienteId = 6,
                DataVenda = new DateTime(2024, 8, 27),
                PrecoVenda = 47000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                VendaId = 7,
                VeiculoId = 7,
                ConcessionariaId = 7,
                ClienteId = 7,
                DataVenda = new DateTime(2024, 8, 28),
                PrecoVenda = 53000.00m,
                ProtocoloVenda =  Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                VendaId = 8,
                VeiculoId = 8,
                ConcessionariaId = 8,
                ClienteId = 8,
                DataVenda = new DateTime(2024, 8, 29),
                PrecoVenda = 48000.00m,
                ProtocoloVenda =  Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            }
        };

            builder.HasData(vendas);
        }
    }
}
