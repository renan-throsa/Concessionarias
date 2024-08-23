using Concessionarias.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concessionarias.Dados.Configs
{
    internal sealed class FabricanteConfig : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.Property(x => x.Id).HasColumnName(nameof(Fabricante) + "Id");
            builder.Property(x => x.Nome).HasMaxLength(100);
            builder.Property(x => x.PaisOrigem).HasMaxLength(50);
            builder.Property(x => x.Website).HasMaxLength(50);

            builder.HasIndex(x => x.Nome).IsUnique();

            List<Fabricante> fabricantes = new List<Fabricante>
        {
            new Fabricante
            {
                Id = 1,
                Nome = "HyperCars",
                PaisOrigem = "Brasil",
                AnoFundacao = 1950,
                Website = "https://fabricantea.com"
            },
            new Fabricante
            {
                Id = 2,
                Nome = "EcoMotors",
                PaisOrigem = "Estados Unidos",
                AnoFundacao = 1925,
                Website = "https://fabricanteb.com"
            },
            new Fabricante
            {
                Id = 3,
                Nome = "SuperCarros",
                PaisOrigem = "Itália",
                AnoFundacao = 1960,
                Website = "https://www.supercarros.com"
            },
            new Fabricante
            {
                Id = 4,
                Nome = "TechMotors",
                PaisOrigem = "Japão",
                AnoFundacao = 1985,
                Website = "https://www.techmotors.co.jp"
            },
            new Fabricante
            {
                Id = 5,
                Nome = "TurboDrive",
                PaisOrigem = "Coreia do Sul",
                AnoFundacao = 2003,
                Website = "https://www.turbodrive"
            },
            new Fabricante
            {
                Id = 6,
                Nome = "Electric Wheels",
                PaisOrigem = "Holanda",
                AnoFundacao = 2006,
                Website = "https://www.wlectricwheels.co.ho"
            }
        };

            builder.HasData(fabricantes);
        }
    }
}
