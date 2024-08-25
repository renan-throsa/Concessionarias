using Concs.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concs.Dados.Configs
{
    internal sealed class TipoVeiculoConfig : IEntityTypeConfiguration<TipoVeiculo>
    {
        public void Configure(EntityTypeBuilder<TipoVeiculo> builder)
        {
            builder.Property(x => x.Id).HasColumnName(nameof(TipoVeiculo) + "Id");
            var tipos = new List<TipoVeiculo>() { new TipoVeiculo { Id = 1, Tipo = "Carro" }, new TipoVeiculo { Id = 2, Tipo = "Moto" }, new TipoVeiculo { Id = 3, Tipo = "Caminhão" } };
            builder.HasData(tipos);
        }
    }
}
