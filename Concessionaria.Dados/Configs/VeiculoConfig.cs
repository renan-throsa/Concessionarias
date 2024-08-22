using Concessionaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concessionaria.Dados.Configs
{
    internal sealed class VeiculoConfig : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.Property(x => x.Modelo).HasMaxLength(100);
            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.HasIndex(x => x.Modelo);

            builder.HasOne(x => x.Fabricante);
            builder.HasOne(x => x.TipoVeiculo);

            List<Veiculo> veiculos = new List<Veiculo>
        {
            new Veiculo
            {
                VeiculoId = 1,
                FabricanteId = 1,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "Sedan",
                AnoFabricacao = 2022,
                Preco = 55000.00m,
                Descricao = "Veículo confortável e econômico.",
                Ativo = true,

            },
            new Veiculo
            {
                VeiculoId = 2,
                FabricanteId = 2,
                TipoVeiculoId = (int)TipoVeiculoEnum.Moto,
                Modelo = "Esportiva",
                AnoFabricacao = 2021,
                Preco = 12000.00m,
                Descricao = "Moto ágil e potente.",
                Ativo = true,

            },
            new Veiculo
            {
                VeiculoId = 3,
                FabricanteId = 3,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "Sedan",
                AnoFabricacao = 2022,
                Preco = 45000.00m,
                Descricao = "Um carro confortável e econômico.",
                Ativo = true,
            },

            new Veiculo
            {
                VeiculoId = 4,
                FabricanteId = 3,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "SUV",
                AnoFabricacao = 2023,
                Preco = 55000.00m,
                Descricao = "Um SUV espaçoso e versátil.",
                Ativo = true,
            },

            new Veiculo
            {
                VeiculoId = 5,
                FabricanteId = 4,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "Hatchback",
                AnoFabricacao = 2024,
                Preco = 35000.00m,
                Descricao = "Um carro compacto e ágil.",
                Ativo = true,

            },

            new Veiculo
            {
                VeiculoId = 6,
                FabricanteId = 5,
                TipoVeiculoId = (int)TipoVeiculoEnum.Caminhão,
                Modelo = "Caminhonete",
                AnoFabricacao = 2023,
                Preco = 65000.00m,
                Descricao = "Uma caminhonete robusta e versátil.",
                Ativo = true,

            },
                new Veiculo
            {
                VeiculoId = 7,
                FabricanteId = 5,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "Hatchback",
                AnoFabricacao = 2024,
                Preco = 35000.00m,
                Descricao = "Um carro compacto e ágil.",
                Ativo = true,
            },

            new Veiculo
            {
                VeiculoId = 8,
                FabricanteId = 6,
                TipoVeiculoId = (int)TipoVeiculoEnum.Caminhão,
                Modelo = "Caminhonete",
                AnoFabricacao = 2023,
                Preco = 65000.00m,
                Descricao = "Uma caminhonete robusta e versátil.",
                Ativo = true,
            },

        };

            builder.HasData(veiculos);

        }
    }
}
