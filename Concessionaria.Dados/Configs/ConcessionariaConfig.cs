using Microsoft.EntityFrameworkCore;

namespace Concessionaria.Dados.Configs
{
    internal sealed class ConcessionariaConfig : IEntityTypeConfiguration<Dominio.Entidades.Concessionaria>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Dominio.Entidades.Concessionaria> builder)
        {
            builder.Property(x => x.Nome).HasMaxLength(100);
            builder.HasIndex(x => x.Nome).IsUnique();

            builder.Property(x => x.Estado).HasMaxLength(50);
            builder.Property(x => x.Cidade).HasMaxLength(50);
            builder.Property(x => x.CEP).HasMaxLength(10);
            builder.Property(x => x.Telefone).HasMaxLength(15);
            builder.Property(x => x.Email).HasMaxLength(100);

            List<Dominio.Entidades.Concessionaria> concessionarias = new List<Dominio.Entidades.Concessionaria>
        {
            new Dominio.Entidades.Concessionaria
            {
                ConcessionariaId = 1,
                Nome = "Concessionária do Vale",
                Endereco = "Rua das Flores, 123",
                Cidade = "São Paulo",
                Estado = "SP",
                CEP = "01234567",
                Telefone = "(11) 9876-5432",
                Email = "contato@concessionariadovale.com.br",
                CapacidadeMaximaVeiculos = 150
            },
            new Dominio.Entidades.Concessionaria
            {
                ConcessionariaId = 2,
                Nome = "Auto Center ABC",
                Endereco = "Av. das Palmeiras, 456",
                Cidade = "Santo André",
                Estado = "SP",
                CEP = "09876543",
                Telefone = "(11) 5555-1234",
                Email = "vendas@autocenterabc.com",
                CapacidadeMaximaVeiculos = 200
            },
            new Dominio.Entidades.Concessionaria
            {
                ConcessionariaId = 3,
                Nome = "Auto Shop Zeta",
                Endereco = "Rua dos Carros, 789",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                CEP = "20000123",
                Telefone = "(21) 9876-5432",
                Email = "vendas@autoshopzeta.com",
                CapacidadeMaximaVeiculos = 180
            },
            new Dominio.Entidades.Concessionaria
            {
                ConcessionariaId = 4,
                Nome = "Mega Motors",
                Endereco = "Av. das Rodovias, 567",
                Cidade = "Belo Horizonte",
                Estado = "MG",
                CEP = "30000456",
                Telefone = "(31) 5555-1234",
                Email = "contato@megamotors.com.br",
                CapacidadeMaximaVeiculos = 220
            },
            new Dominio.Entidades.Concessionaria
            {
                ConcessionariaId = 5,
                Nome = "Carros Express",
                Endereco = "Av. das Velocidades, 789",
                Cidade = "Curitiba",
                Estado = "PR",
                CEP = "80000789",
                Telefone = "(41) 5555-6789",
                Email = "vendas@carrosexpress.com",
                CapacidadeMaximaVeiculos = 190
            },
            new Dominio.Entidades.Concessionaria
            {
                ConcessionariaId = 6,
                Nome = "Auto Center XYZ",
                Endereco = "Rua dos Motores, 567",
                Cidade = "Porto Alegre",
                Estado = "RS",
                CEP = "90000123",
                Telefone = "(51) 9876-2345",
                Email = "contato@autocenterxyz.com",
                CapacidadeMaximaVeiculos = 210
            },
            new Dominio.Entidades.Concessionaria
            {
                ConcessionariaId = 7,
                Nome = "Carros Rápidos",
                Endereco = "Av. das Acelerações, 789",
                Cidade = "Florianópolis",
                Estado = "SC",
                CEP = "88000789",
                Telefone = "(48) 9876-5678",
                Email = "vendas@carrosrapidos.com",
                CapacidadeMaximaVeiculos = 200
            },
            new Dominio.Entidades.Concessionaria
            {
                ConcessionariaId = 8,
                Nome = "Auto Center ABCD",
                Endereco = "Rua dos Motores, 123",
                Cidade = "Recife",
                Estado = "PE",
                CEP = "50000123",
                Telefone = "(81) 5555-6789",
                Email = "contato@autocenterabcd.com",
                CapacidadeMaximaVeiculos = 230
            }
        };
            builder.HasData(concessionarias);
        }
    }
}
