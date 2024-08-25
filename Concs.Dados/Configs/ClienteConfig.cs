using Concs.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concs.Dados.Configs
{
    internal sealed class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Id).HasColumnName(nameof(Cliente) + "Id");
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.CPF).HasMaxLength(11);
            builder.Property(x => x.Telefone).HasMaxLength(15);

            builder.HasIndex(x => x.CPF).IsUnique();

            List<Cliente> clientes = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "Maria Silva", CPF = "12345678901", Telefone = "(11) 98765-4321",Ativo = true },
            new Cliente { Id = 2, Nome = "João Santos", CPF = "98765432109", Telefone = "(21) 5555-1234",Ativo = true },
            new Cliente { Id = 3, Nome = "Carlos Oliveira", CPF = "78912345602", Telefone = "(31) 98765-9876",Ativo = true },
            new Cliente { Id = 4, Nome = "Ana Rodrigues", CPF = "65432198703", Telefone = "(41) 5555-5678" , Ativo = true},
            new Cliente { Id = 5, Nome = "Fernanda Lima", CPF = "45678912304", Telefone = "(51) 98765-4321" , Ativo = true},
            new Cliente { Id = 6, Nome = "Rafael Souza", CPF = "32165498705", Telefone = "(21) 5555-6789" , Ativo = true},
            new Cliente { Id = 7, Nome = "Lúcia Santos", CPF = "65498732106", Telefone = "(31) 98765-1234" , Ativo = true},
            new Cliente { Id = 8, Nome = "Pedro Alves", CPF = "98732165407", Telefone = "(41) 5555-2345" , Ativo = true},
            new Cliente { Id = 9, Nome = "Mariana Oliveira", CPF = "78945612308", Telefone = "(51) 98765-5678" , Ativo = true},
            new Cliente { Id = 10, Nome = "Lucas Rodrigues", CPF = "98732165409", Telefone = "(21) 5555-7890" , Ativo = true},
            new Cliente { Id = 11, Nome = "Isabela Almeida", CPF = "65478932110", Telefone = "(31) 98765-2345" , Ativo = true},
            new Cliente { Id = 12, Nome = "Gustavo Lima", CPF = "98765432111", Telefone = "(41) 5555-3456" , Ativo = true},
            new Cliente { Id = 13, Nome = "Larissa Costa", CPF = "78912345612", Telefone = "(51) 98765-6789" , Ativo = true},
            new Cliente { Id = 14, Nome = "Ricardo Santos", CPF = "98765432113", Telefone = "(21) 5555-8901" , Ativo = true},
            new Cliente { Id = 15, Nome = "Camila Alves", CPF = "65498732114", Telefone = "(31) 98765-3456" , Ativo = true},
            new Cliente { Id = 16, Nome = "Fábio Lima", CPF = "98732165415", Telefone = "(41) 5555-4567" , Ativo = true}
        };

            builder.HasData(clientes);

        }
    }
}
