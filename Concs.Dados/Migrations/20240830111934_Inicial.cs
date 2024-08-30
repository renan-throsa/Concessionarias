using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concs.Dados.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Concessionarias",
                columns: table => new
                {
                    ConcessionariaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CapacidadeMaximaVeiculos = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concessionarias", x => x.ConcessionariaId);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    FabricanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaisOrigem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnoFundacao = table.Column<int>(type: "int", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.FabricanteId);
                });

            migrationBuilder.CreateTable(
                name: "TiposVeiculos",
                columns: table => new
                {
                    TipoVeiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposVeiculos", x => x.TipoVeiculoId);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FabricanteId = table.Column<int>(type: "int", nullable: false),
                    TipoVeiculoId = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.VeiculoId);
                    table.ForeignKey(
                        name: "FK_Veiculos_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "FabricanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Veiculos_TiposVeiculos_TipoVeiculoId",
                        column: x => x.TipoVeiculoId,
                        principalTable: "TiposVeiculos",
                        principalColumn: "TipoVeiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    VendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    ConcessionariaId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProtocoloVenda = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Concessionarias_ConcessionariaId",
                        column: x => x.ConcessionariaId,
                        principalTable: "Concessionarias",
                        principalColumn: "ConcessionariaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Ativo", "CPF", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, "12345678901", "Maria Silva", "(11) 98765-4321" },
                    { 2, true, "98765432109", "João Santos", "(21) 5555-1234" },
                    { 3, true, "78912345602", "Carlos Oliveira", "(31) 98765-9876" },
                    { 4, true, "65432198703", "Ana Rodrigues", "(41) 5555-5678" },
                    { 5, true, "45678912304", "Fernanda Lima", "(51) 98765-4321" },
                    { 6, true, "32165498705", "Rafael Souza", "(21) 5555-6789" },
                    { 7, true, "65498732106", "Lúcia Santos", "(31) 98765-1234" },
                    { 8, true, "98732165407", "Pedro Alves", "(41) 5555-2345" },
                    { 9, true, "78945612308", "Mariana Oliveira", "(51) 98765-5678" },
                    { 10, true, "98732165409", "Lucas Rodrigues", "(21) 5555-7890" },
                    { 11, true, "65478932110", "Isabela Almeida", "(31) 98765-2345" },
                    { 12, true, "98765432111", "Gustavo Lima", "(41) 5555-3456" },
                    { 13, true, "78912345612", "Larissa Costa", "(51) 98765-6789" },
                    { 14, true, "98765432113", "Ricardo Santos", "(21) 5555-8901" },
                    { 15, true, "65498732114", "Camila Alves", "(31) 98765-3456" },
                    { 16, true, "98732165415", "Fábio Lima", "(41) 5555-4567" }
                });

            migrationBuilder.InsertData(
                table: "Concessionarias",
                columns: new[] { "ConcessionariaId", "Ativo", "CEP", "CapacidadeMaximaVeiculos", "Cidade", "Email", "Endereco", "Estado", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, "01234567", 150, "São Paulo", "contato@concessionariadovale.com.br", "Rua das Flores, 123", "São Paulo", "Concessionária do Vale", "(11) 9876-5432" },
                    { 2, true, "09876543", 200, "Santo André", "vendas@autocenterabc.com", "Av. das Palmeiras, 456", "São Paulo", "Auto Center ABC", "(11) 5555-1234" },
                    { 3, true, "20000123", 180, "Rio de Janeiro", "vendas@autoshopzeta.com", "Rua dos Carros, 789", "Rio de Janeiro", "Auto Shop Zeta", "(21) 9876-5432" },
                    { 4, true, "30000456", 220, "Belo Horizonte", "contato@megamotors.com.br", "Av. das Rodovias, 567", "Minas Gerais", "Mega Motors", "(31) 5555-1234" },
                    { 5, true, "80000789", 190, "Curitiba", "vendas@carrosexpress.com", "Av. das Velocidades, 789", "Paraná", "Carros Express", "(41) 5555-6789" },
                    { 6, true, "90000123", 210, "Porto Alegre", "contato@autocenterxyz.com", "Rua dos Motores, 567", "Rio Grande do Sul", "Auto Center XYZ", "(51) 9876-2345" },
                    { 7, true, "88000789", 200, "Florianópolis", "vendas@carrosrapidos.com", "Av. das Acelerações, 789", "Santa Catarina", "Carros Rápidos", "(48) 9876-5678" },
                    { 8, true, "50000123", 230, "Recife", "contato@autocenterabcd.com", "Rua dos Motores, 123", "Pernambuco", "Auto Center ABCD", "(81) 5555-6789" }
                });

            migrationBuilder.InsertData(
                table: "Fabricantes",
                columns: new[] { "FabricanteId", "AnoFundacao", "Ativo", "Nome", "PaisOrigem", "Website" },
                values: new object[,]
                {
                    { 1, 1950, true, "HyperCars", "Brasil", "https://fabricantea.com" },
                    { 2, 1925, true, "EcoMotors", "Estados Unidos", "https://fabricanteb.com" },
                    { 3, 1960, true, "SuperCarros", "Itália", "https://www.supercarros.com" },
                    { 4, 1985, true, "TechMotors", "Japão", "https://www.techmotors.co.jp" },
                    { 5, 2003, true, "TurboDrive", "Coreia do Sul", "https://www.turbodrive" },
                    { 6, 2006, true, "Electric Wheels", "Holanda", "https://www.wlectricwheels.co.ho" }
                });

            migrationBuilder.InsertData(
                table: "TiposVeiculos",
                columns: new[] { "TipoVeiculoId", "Ativo", "Tipo" },
                values: new object[,]
                {
                    { 1, true, "Carro" },
                    { 2, true, "Moto" },
                    { 3, true, "Caminhão" }
                });

            migrationBuilder.InsertData(
                table: "Veiculos",
                columns: new[] { "VeiculoId", "AnoFabricacao", "Ativo", "Descricao", "FabricanteId", "Modelo", "Preco", "TipoVeiculoId" },
                values: new object[,]
                {
                    { 1, 2022, true, "Veículo confortável e econômico.", 1, "Sedan", 55000.00m, 1 },
                    { 2, 2021, true, "Moto ágil e potente.", 2, "Esportiva", 12000.00m, 2 },
                    { 3, 2022, true, "Um carro confortável e econômico.", 3, "Sedan", 45000.00m, 1 },
                    { 4, 2023, true, "Um SUV espaçoso e versátil.", 3, "SUV", 55000.00m, 1 },
                    { 5, 2024, true, "Um carro compacto e ágil.", 4, "Hatchback", 35000.00m, 1 },
                    { 6, 2023, true, "Uma caminhonete robusta e versátil.", 5, "Caminhonete", 65000.00m, 3 },
                    { 7, 2024, true, "Um carro compacto e ágil.", 5, "Hatchback", 35000.00m, 1 },
                    { 8, 2023, true, "Uma caminhonete robusta e versátil.", 6, "Caminhonete", 65000.00m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Vendas",
                columns: new[] { "VendaId", "Ativo", "ClienteId", "ConcessionariaId", "DataVenda", "PrecoVenda", "ProtocoloVenda", "VeiculoId" },
                values: new object[,]
                {
                    { 1, true, 1, 1, new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000.00m, "CF122B6A-9946-49E8-A", 1 },
                    { 2, true, 2, 1, new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000.00m, "A46C5E56-AE03-43E0-B", 2 },
                    { 3, true, 3, 2, new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 55000.00m, "09048A2D-3ECA-4CD8-8", 3 },
                    { 4, true, 4, 2, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 48000.00m, "00CBAE7C-6763-4AC5-9", 4 },
                    { 5, true, 5, 5, new DateTime(2024, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 52000.00m, "82E927D2-3861-4EE2-A", 5 },
                    { 6, true, 6, 5, new DateTime(2024, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 47000.00m, "44D7901F-0F9D-4F5D-A", 6 },
                    { 7, true, 7, 7, new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 53000.00m, "75EF1BC2-03A4-455C-8", 7 },
                    { 8, true, 8, 8, new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 48000.00m, "02E52FE5-6F20-4893-8", 8 },
                    { 9, true, 8, 8, new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000.00m, "AFFD5F09-7266-4D05-B", 8 },
                    { 10, true, 7, 7, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 45000.00m, "528ADF11-0867-4C69-B", 7 },
                    { 11, true, 16, 6, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 55000.00m, "65CB24B0-33F2-4F55-8", 6 },
                    { 12, true, 15, 5, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 48000.00m, "7FD9663B-AB7D-4EB3-9", 5 },
                    { 13, true, 14, 7, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 52000.00m, "7E5D30AA-24FC-46DE-B", 4 },
                    { 14, true, 13, 5, new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 47000.00m, "95684945-C254-421D-9", 3 },
                    { 15, true, 9, 3, new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 53000.00m, "06A001F0-CC76-4033-A", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CPF",
                table: "Clientes",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Concessionarias_Nome",
                table: "Concessionarias",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fabricantes_Nome",
                table: "Fabricantes",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_FabricanteId",
                table: "Veiculos",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_Modelo",
                table: "Veiculos",
                column: "Modelo");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_TipoVeiculoId",
                table: "Veiculos",
                column: "TipoVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ConcessionariaId",
                table: "Vendas",
                column: "ConcessionariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_VeiculoId",
                table: "Vendas",
                column: "VeiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Concessionarias");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "TiposVeiculos");
        }
    }
}
