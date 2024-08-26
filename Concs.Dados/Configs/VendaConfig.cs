using Concs.Dados.Utilitarios;
using Concs.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concs.Dados.Configs
{
    internal sealed class VendaConfig : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.Property(x => x.Id).HasColumnName(nameof(Venda) + "Id");
            builder.Property(x => x.DataVenda).HasColumnType("datetime");
            builder.Property(x => x.ProtocoloVenda).HasMaxLength(20).HasValueGenerator((x, y) => new GeradorDeProtocolo());

            builder.HasOne(x => x.Cliente);
            builder.HasOne(x => x.Veiculo);
            builder.HasOne(x => x.Concessionaria);

            List<Venda> vendas = new List<Venda>
        {
            new Venda
            {
                Id = 1,
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
                Id = 2,
                VeiculoId = 2,
                ConcessionariaId = 1,
                ClienteId = 2,
                DataVenda = new DateTime(2024, 8, 23),
                PrecoVenda = 45000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0,20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 3,
                VeiculoId = 3,
                ConcessionariaId = 2,
                ClienteId = 3,
                DataVenda = new DateTime(2024, 8, 24),
                PrecoVenda = 55000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0,20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 4,
                VeiculoId = 4,
                ConcessionariaId = 2,
                ClienteId = 4,
                DataVenda = new DateTime(2024, 8, 25),
                PrecoVenda = 48000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 5,
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
                Id = 6,
                VeiculoId = 6,
                ConcessionariaId = 5,
                ClienteId = 6,
                DataVenda = new DateTime(2024, 8, 27),
                PrecoVenda = 47000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 7,
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
                Id = 8,
                VeiculoId = 8,
                ConcessionariaId = 8,
                ClienteId = 8,
                DataVenda = new DateTime(2024, 8, 29),
                PrecoVenda = 48000.00m,
                ProtocoloVenda =  Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 9,
                VeiculoId = 8,
                ConcessionariaId = 8,
                ClienteId = 8,
                DataVenda = new DateTime(2024, 7, 22),
                PrecoVenda = 50000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0,20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 10,
                VeiculoId = 7,
                ConcessionariaId = 7,
                ClienteId = 7,
                DataVenda = new DateTime(2024, 7, 23),
                PrecoVenda = 45000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0,20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 11,
                VeiculoId = 6,
                ConcessionariaId = 6,
                ClienteId = 16,
                DataVenda = new DateTime(2024, 6, 24),
                PrecoVenda = 55000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0,20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 12,
                VeiculoId = 5,
                ConcessionariaId = 5,
                ClienteId = 15,
                DataVenda = new DateTime(2024, 6, 25),
                PrecoVenda = 48000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 13,
                VeiculoId = 4,
                ConcessionariaId = 7,
                ClienteId = 14,
                DataVenda = new DateTime(2024, 5, 26),
                PrecoVenda = 52000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 14,
                VeiculoId = 3,
                ConcessionariaId = 5,
                ClienteId = 13,
                DataVenda = new DateTime(2024, 5, 27),
                PrecoVenda = 47000.00m,
                ProtocoloVenda = Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
            new Venda
            {
                Id = 15,
                VeiculoId = 2,
                ConcessionariaId = 3,
                ClienteId = 9,
                DataVenda = new DateTime(2024, 5, 28),
                PrecoVenda = 53000.00m,
                ProtocoloVenda =  Guid.NewGuid().ToString().Substring(0, 20).ToUpper(),
                Ativo = true
            },
           
        };

            builder.HasData(vendas);
        }
    }
}
