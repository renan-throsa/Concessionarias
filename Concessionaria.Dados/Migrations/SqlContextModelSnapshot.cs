﻿// <auto-generated />
using System;
using Concessionaria.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Concessionaria.Dados.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Concessionaria.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ClienteId");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            ClienteId = 1,
                            Ativo = true,
                            CPF = "12345678901",
                            Nome = "Maria Silva",
                            Telefone = "(11) 98765-4321"
                        },
                        new
                        {
                            ClienteId = 2,
                            Ativo = true,
                            CPF = "98765432109",
                            Nome = "João Santos",
                            Telefone = "(21) 5555-1234"
                        },
                        new
                        {
                            ClienteId = 3,
                            Ativo = true,
                            CPF = "78912345602",
                            Nome = "Carlos Oliveira",
                            Telefone = "(31) 98765-9876"
                        },
                        new
                        {
                            ClienteId = 4,
                            Ativo = true,
                            CPF = "65432198703",
                            Nome = "Ana Rodrigues",
                            Telefone = "(41) 5555-5678"
                        },
                        new
                        {
                            ClienteId = 5,
                            Ativo = true,
                            CPF = "45678912304",
                            Nome = "Fernanda Lima",
                            Telefone = "(51) 98765-4321"
                        },
                        new
                        {
                            ClienteId = 6,
                            Ativo = true,
                            CPF = "32165498705",
                            Nome = "Rafael Souza",
                            Telefone = "(21) 5555-6789"
                        },
                        new
                        {
                            ClienteId = 7,
                            Ativo = true,
                            CPF = "65498732106",
                            Nome = "Lúcia Santos",
                            Telefone = "(31) 98765-1234"
                        },
                        new
                        {
                            ClienteId = 8,
                            Ativo = true,
                            CPF = "98732165407",
                            Nome = "Pedro Alves",
                            Telefone = "(41) 5555-2345"
                        },
                        new
                        {
                            ClienteId = 9,
                            Ativo = true,
                            CPF = "78945612308",
                            Nome = "Mariana Oliveira",
                            Telefone = "(51) 98765-5678"
                        },
                        new
                        {
                            ClienteId = 10,
                            Ativo = true,
                            CPF = "98732165409",
                            Nome = "Lucas Rodrigues",
                            Telefone = "(21) 5555-7890"
                        },
                        new
                        {
                            ClienteId = 11,
                            Ativo = true,
                            CPF = "65478932110",
                            Nome = "Isabela Almeida",
                            Telefone = "(31) 98765-2345"
                        },
                        new
                        {
                            ClienteId = 12,
                            Ativo = true,
                            CPF = "98765432111",
                            Nome = "Gustavo Lima",
                            Telefone = "(41) 5555-3456"
                        },
                        new
                        {
                            ClienteId = 13,
                            Ativo = true,
                            CPF = "78912345612",
                            Nome = "Larissa Costa",
                            Telefone = "(51) 98765-6789"
                        },
                        new
                        {
                            ClienteId = 14,
                            Ativo = true,
                            CPF = "98765432113",
                            Nome = "Ricardo Santos",
                            Telefone = "(21) 5555-8901"
                        },
                        new
                        {
                            ClienteId = 15,
                            Ativo = true,
                            CPF = "65498732114",
                            Nome = "Camila Alves",
                            Telefone = "(31) 98765-3456"
                        },
                        new
                        {
                            ClienteId = 16,
                            Ativo = true,
                            CPF = "98732165415",
                            Nome = "Fábio Lima",
                            Telefone = "(41) 5555-4567"
                        });
                });

            modelBuilder.Entity("Concessionaria.Dominio.Entidades.Concessionaria", b =>
                {
                    b.Property<int>("ConcessionariaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConcessionariaId"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("CapacidadeMaximaVeiculos")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ConcessionariaId");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Concessionarias");

                    b.HasData(
                        new
                        {
                            ConcessionariaId = 1,
                            Ativo = false,
                            CEP = "01234567",
                            CapacidadeMaximaVeiculos = 150,
                            Cidade = "São Paulo",
                            Email = "contato@concessionariadovale.com.br",
                            Endereco = "Rua das Flores, 123",
                            Estado = "SP",
                            Nome = "Concessionária do Vale",
                            Telefone = "(11) 9876-5432"
                        },
                        new
                        {
                            ConcessionariaId = 2,
                            Ativo = false,
                            CEP = "09876543",
                            CapacidadeMaximaVeiculos = 200,
                            Cidade = "Santo André",
                            Email = "vendas@autocenterabc.com",
                            Endereco = "Av. das Palmeiras, 456",
                            Estado = "SP",
                            Nome = "Auto Center ABC",
                            Telefone = "(11) 5555-1234"
                        },
                        new
                        {
                            ConcessionariaId = 3,
                            Ativo = false,
                            CEP = "20000123",
                            CapacidadeMaximaVeiculos = 180,
                            Cidade = "Rio de Janeiro",
                            Email = "vendas@autoshopzeta.com",
                            Endereco = "Rua dos Carros, 789",
                            Estado = "RJ",
                            Nome = "Auto Shop Zeta",
                            Telefone = "(21) 9876-5432"
                        },
                        new
                        {
                            ConcessionariaId = 4,
                            Ativo = false,
                            CEP = "30000456",
                            CapacidadeMaximaVeiculos = 220,
                            Cidade = "Belo Horizonte",
                            Email = "contato@megamotors.com.br",
                            Endereco = "Av. das Rodovias, 567",
                            Estado = "MG",
                            Nome = "Mega Motors",
                            Telefone = "(31) 5555-1234"
                        },
                        new
                        {
                            ConcessionariaId = 5,
                            Ativo = false,
                            CEP = "80000789",
                            CapacidadeMaximaVeiculos = 190,
                            Cidade = "Curitiba",
                            Email = "vendas@carrosexpress.com",
                            Endereco = "Av. das Velocidades, 789",
                            Estado = "PR",
                            Nome = "Carros Express",
                            Telefone = "(41) 5555-6789"
                        },
                        new
                        {
                            ConcessionariaId = 6,
                            Ativo = false,
                            CEP = "90000123",
                            CapacidadeMaximaVeiculos = 210,
                            Cidade = "Porto Alegre",
                            Email = "contato@autocenterxyz.com",
                            Endereco = "Rua dos Motores, 567",
                            Estado = "RS",
                            Nome = "Auto Center XYZ",
                            Telefone = "(51) 9876-2345"
                        },
                        new
                        {
                            ConcessionariaId = 7,
                            Ativo = false,
                            CEP = "88000789",
                            CapacidadeMaximaVeiculos = 200,
                            Cidade = "Florianópolis",
                            Email = "vendas@carrosrapidos.com",
                            Endereco = "Av. das Acelerações, 789",
                            Estado = "SC",
                            Nome = "Carros Rápidos",
                            Telefone = "(48) 9876-5678"
                        },
                        new
                        {
                            ConcessionariaId = 8,
                            Ativo = false,
                            CEP = "50000123",
                            CapacidadeMaximaVeiculos = 230,
                            Cidade = "Recife",
                            Email = "contato@autocenterabcd.com",
                            Endereco = "Rua dos Motores, 123",
                            Estado = "PE",
                            Nome = "Auto Center ABCD",
                            Telefone = "(81) 5555-6789"
                        });
                });

            modelBuilder.Entity("Concessionaria.Dominio.Entidades.Fabricante", b =>
                {
                    b.Property<int>("FabricanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FabricanteId"), 1L, 1);

                    b.Property<int>("AnoFundacao")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PaisOrigem")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FabricanteId");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Fabricantes");

                    b.HasData(
                        new
                        {
                            FabricanteId = 1,
                            AnoFundacao = 1950,
                            Ativo = false,
                            Nome = "HyperCars",
                            PaisOrigem = "Brasil",
                            Website = "https://fabricantea.com"
                        },
                        new
                        {
                            FabricanteId = 2,
                            AnoFundacao = 1925,
                            Ativo = false,
                            Nome = "EcoMotors",
                            PaisOrigem = "Estados Unidos",
                            Website = "https://fabricanteb.com"
                        },
                        new
                        {
                            FabricanteId = 3,
                            AnoFundacao = 1960,
                            Ativo = false,
                            Nome = "SuperCarros",
                            PaisOrigem = "Itália",
                            Website = "https://www.supercarros.com"
                        },
                        new
                        {
                            FabricanteId = 4,
                            AnoFundacao = 1985,
                            Ativo = false,
                            Nome = "TechMotors",
                            PaisOrigem = "Japão",
                            Website = "https://www.techmotors.co.jp"
                        },
                        new
                        {
                            FabricanteId = 5,
                            AnoFundacao = 2003,
                            Ativo = false,
                            Nome = "TurboDrive",
                            PaisOrigem = "Coreia do Sul",
                            Website = "https://www.turbodrive"
                        },
                        new
                        {
                            FabricanteId = 6,
                            AnoFundacao = 2006,
                            Ativo = false,
                            Nome = "Electric Wheels",
                            PaisOrigem = "Holanda",
                            Website = "https://www.wlectricwheels.co.ho"
                        });
                });

            modelBuilder.Entity("Concessionaria.Dominio.Entidades.TipoVeiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TipoVeiculo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = false,
                            Tipo = "Carro"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = false,
                            Tipo = "Moto"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = false,
                            Tipo = "Caminhão"
                        });
                });

            modelBuilder.Entity("Concessionaria.Dominio.Entidades.Veiculo", b =>
                {
                    b.Property<int>("VeiculoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VeiculoId"), 1L, 1);

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FabricanteId")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoVeiculoId")
                        .HasColumnType("int");

                    b.HasKey("VeiculoId");

                    b.HasIndex("FabricanteId");

                    b.HasIndex("Modelo");

                    b.HasIndex("TipoVeiculoId");

                    b.ToTable("Veiculos");

                    b.HasData(
                        new
                        {
                            VeiculoId = 1,
                            AnoFabricacao = 2022,
                            Ativo = true,
                            Descricao = "Veículo confortável e econômico.",
                            FabricanteId = 1,
                            Modelo = "Sedan",
                            Preco = 55000.00m,
                            TipoVeiculoId = 1
                        },
                        new
                        {
                            VeiculoId = 2,
                            AnoFabricacao = 2021,
                            Ativo = true,
                            Descricao = "Moto ágil e potente.",
                            FabricanteId = 2,
                            Modelo = "Esportiva",
                            Preco = 12000.00m,
                            TipoVeiculoId = 2
                        },
                        new
                        {
                            VeiculoId = 3,
                            AnoFabricacao = 2022,
                            Ativo = true,
                            Descricao = "Um carro confortável e econômico.",
                            FabricanteId = 3,
                            Modelo = "Sedan",
                            Preco = 45000.00m,
                            TipoVeiculoId = 1
                        },
                        new
                        {
                            VeiculoId = 4,
                            AnoFabricacao = 2023,
                            Ativo = true,
                            Descricao = "Um SUV espaçoso e versátil.",
                            FabricanteId = 3,
                            Modelo = "SUV",
                            Preco = 55000.00m,
                            TipoVeiculoId = 1
                        },
                        new
                        {
                            VeiculoId = 5,
                            AnoFabricacao = 2024,
                            Ativo = true,
                            Descricao = "Um carro compacto e ágil.",
                            FabricanteId = 4,
                            Modelo = "Hatchback",
                            Preco = 35000.00m,
                            TipoVeiculoId = 1
                        },
                        new
                        {
                            VeiculoId = 6,
                            AnoFabricacao = 2023,
                            Ativo = true,
                            Descricao = "Uma caminhonete robusta e versátil.",
                            FabricanteId = 5,
                            Modelo = "Caminhonete",
                            Preco = 65000.00m,
                            TipoVeiculoId = 3
                        },
                        new
                        {
                            VeiculoId = 7,
                            AnoFabricacao = 2024,
                            Ativo = true,
                            Descricao = "Um carro compacto e ágil.",
                            FabricanteId = 5,
                            Modelo = "Hatchback",
                            Preco = 35000.00m,
                            TipoVeiculoId = 1
                        },
                        new
                        {
                            VeiculoId = 8,
                            AnoFabricacao = 2023,
                            Ativo = true,
                            Descricao = "Uma caminhonete robusta e versátil.",
                            FabricanteId = 6,
                            Modelo = "Caminhonete",
                            Preco = 65000.00m,
                            TipoVeiculoId = 3
                        });
                });

            modelBuilder.Entity("Concessionaria.Dominio.Entidades.Venda", b =>
                {
                    b.Property<int>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VendaId"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ConcessionariaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataVenda")
                        .HasColumnType("datetime");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProtocoloVenda")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("VendaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ConcessionariaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Vendas");

                    b.HasData(
                        new
                        {
                            VendaId = 1,
                            Ativo = true,
                            ClienteId = 1,
                            ConcessionariaId = 1,
                            DataVenda = new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrecoVenda = 50000.00m,
                            ProtocoloVenda = "9DA5C5D3-0F82-4FF4-8",
                            VeiculoId = 1
                        },
                        new
                        {
                            VendaId = 2,
                            Ativo = true,
                            ClienteId = 2,
                            ConcessionariaId = 2,
                            DataVenda = new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrecoVenda = 45000.00m,
                            ProtocoloVenda = "0AC88D16-3F6B-4B4E-8",
                            VeiculoId = 2
                        },
                        new
                        {
                            VendaId = 3,
                            Ativo = true,
                            ClienteId = 3,
                            ConcessionariaId = 3,
                            DataVenda = new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrecoVenda = 55000.00m,
                            ProtocoloVenda = "771B1D96-CCA7-4286-A",
                            VeiculoId = 3
                        },
                        new
                        {
                            VendaId = 4,
                            Ativo = true,
                            ClienteId = 4,
                            ConcessionariaId = 4,
                            DataVenda = new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrecoVenda = 48000.00m,
                            ProtocoloVenda = "93AEC545-A56C-47DF-B",
                            VeiculoId = 4
                        },
                        new
                        {
                            VendaId = 5,
                            Ativo = true,
                            ClienteId = 5,
                            ConcessionariaId = 5,
                            DataVenda = new DateTime(2024, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrecoVenda = 52000.00m,
                            ProtocoloVenda = "B6B6CCF3-DE88-4773-B",
                            VeiculoId = 5
                        },
                        new
                        {
                            VendaId = 6,
                            Ativo = true,
                            ClienteId = 6,
                            ConcessionariaId = 6,
                            DataVenda = new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrecoVenda = 47000.00m,
                            ProtocoloVenda = "A8828DC4-D65A-44BE-9",
                            VeiculoId = 6
                        },
                        new
                        {
                            VendaId = 7,
                            Ativo = true,
                            ClienteId = 7,
                            ConcessionariaId = 7,
                            DataVenda = new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrecoVenda = 53000.00m,
                            ProtocoloVenda = "A90F647A-9483-4D32-A",
                            VeiculoId = 7
                        },
                        new
                        {
                            VendaId = 8,
                            Ativo = true,
                            ClienteId = 8,
                            ConcessionariaId = 8,
                            DataVenda = new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PrecoVenda = 48000.00m,
                            ProtocoloVenda = "84449071-A480-4CD3-B",
                            VeiculoId = 8
                        });
                });

            modelBuilder.Entity("Concessionaria.Dominio.Entidades.Veiculo", b =>
                {
                    b.HasOne("Concessionaria.Dominio.Entidades.Fabricante", "Fabricante")
                        .WithMany()
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concessionaria.Dominio.Entidades.TipoVeiculo", "TipoVeiculo")
                        .WithMany()
                        .HasForeignKey("TipoVeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");

                    b.Navigation("TipoVeiculo");
                });

            modelBuilder.Entity("Concessionaria.Dominio.Entidades.Venda", b =>
                {
                    b.HasOne("Concessionaria.Dominio.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concessionaria.Dominio.Entidades.Concessionaria", "Concessionaria")
                        .WithMany()
                        .HasForeignKey("ConcessionariaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concessionaria.Dominio.Entidades.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Concessionaria");

                    b.Navigation("Veiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
