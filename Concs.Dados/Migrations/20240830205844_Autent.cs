using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Concs.Dados.Migrations
{
    public partial class Autent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "75a9210e-1eec-4b54-9b1c-c2b8894d2aaa", "taniapatriciabernardes@agen-pegeuot.com.br", true, true, null, "TANIAPATRICIABERNARDES@AGEN-PEGEUOT.COM.BR", "TÂNIA PATRÍCIA CAROLINE BERNARDES", "AQAAAAEAACcQAAAAEJz8uiWzQLorMKL6THPe78UFrwtsdIo6YfxLwUjxHi8j3iBVlbzXdvJIYHQah/7a9w==", "(92) 99115-2024", true, "e2384a85-6da0-47f6-b7ac-2902dc1e2ff5", false, "Tânia Patrícia Caroline Bernardes" },
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", 0, "fd978318-20ff-4950-a63c-b2cf239c3f25", "thales.juan.pereira@santosferreira.adv.br", true, true, null, "THALES.JUAN.PEREIRA@SANTOSFERREIRA.ADV.BR", "THALES JUAN PEREIRA", "AQAAAAEAACcQAAAAEK+cwbSpJ+papHkjt0FkaVboQ0GnixjH9h8pdoOkPOrD/YNqv3JbCgmCnRvcIwNx9w==", "(98) 99749-3175", true, "7c33b464-13ce-48d9-a764-1858f6f9e6ff", false, "Thales Juan Pereira" },
                    { "88ecdfcb-85b4-4b8a-969e-47a4d07701bb", 0, "907bf840-c70f-4f63-bf86-917431f413e6", "manoelhugocarvalho@demasi.com.br", true, true, null, "MANOELHUGOCARVALHO@DEMASI.COM.BR", "MANOELHUGOCARVALHO@DEMASI.COM.BR", "AQAAAAEAACcQAAAAEMC/VuaOtFbfFLQG7ahezLegA+zaLkdBsxUhIY1xoz9/dCD8nzMegnyCrNiun4kxpg==", "(79) 99598-4047", true, "28bb9bf5-0ba1-4d0a-b542-7f49ef614aaf", false, "Manoel Hugo Carvalho" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", 0, "c7e9231c-639b-4e2e-8ae2-60cf922d82a9", "esther-nogueira86@edu.uniso.br", true, true, null, "ESTHER-NOGUEIRA86@EDU.UNISO.BR", "ESTHER MANUELA NATÁLIA NOGUEIRA", "AQAAAAEAACcQAAAAEMzt46uF50BsJfVRITrFual9VOsYoKSFJsGfsO5UHd4CPqKYCkeaHTi/wsyQGq1tXQ==", "(98) 98876-8556", true, "c48d722d-e6bc-4bdb-8fad-958791a36caa", false, "Esther Manuela Natália Nogueira" }
                });

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 1,
                column: "ProtocoloVenda",
                value: "DAF77E51-689D-476B-A");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 2,
                column: "ProtocoloVenda",
                value: "E5744385-23A1-4103-B");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 3,
                column: "ProtocoloVenda",
                value: "1B2A47EF-D0F6-42F7-8");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 4,
                column: "ProtocoloVenda",
                value: "992A4573-32D4-486E-8");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 5,
                column: "ProtocoloVenda",
                value: "2A488519-2A0A-4EC2-B");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 6,
                column: "ProtocoloVenda",
                value: "D27C92B1-8A09-4631-A");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 7,
                column: "ProtocoloVenda",
                value: "BF870959-A3AD-49F1-A");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 8,
                column: "ProtocoloVenda",
                value: "3D4F07D3-58A9-4C36-8");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 9,
                column: "ProtocoloVenda",
                value: "D014E1EE-1815-4330-8");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 10,
                column: "ProtocoloVenda",
                value: "D4A5A33C-C97C-481F-9");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 11,
                column: "ProtocoloVenda",
                value: "BECDC76B-2A6B-4B9B-B");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 12,
                column: "ProtocoloVenda",
                value: "54645376-B7B3-4053-9");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 13,
                column: "ProtocoloVenda",
                value: "F3373587-EFD6-4F2A-9");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 14,
                column: "ProtocoloVenda",
                value: "07150DDD-D2A9-400D-8");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 15,
                column: "ProtocoloVenda",
                value: "0FEE5AB8-2FB5-4462-8");

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Permissões", "Fabricante.Ler", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 2, "Permissões", "Fabricante.Inserir", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 3, "Permissões", "Fabricante.Atualizar", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 4, "Permissões", "Veículo.Ler", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 5, "Permissões", "Veículo.Inserir", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 6, "Permissões", "Veículo.Atualizar", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 7, "Permissões", "Concessionária.Ler", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 8, "Permissões", "Concessionária.Inserir", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 9, "Permissões", "Concessionária.Atualizar", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 10, "Permissões", "Venda.Ler", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 11, "Permissões", "Venda.Inserir", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 12, "Permissões", "Venda.Atualizar", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 13, "Permissões", "Cliente.Ler", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 14, "Permissões", "Cliente.Inserir", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 15, "Permissões", "Cliente.Atualizar", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 16, "Permissões", "Relatorio.Ler", "88ecdfcb-85b4-4b8a-969e-47a4d07701bb" },
                    { 17, "Permissões", "Fabricante.Ler", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 18, "Permissões", "Veículo.Ler", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 19, "Permissões", "Veículo.Inserir", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 20, "Permissões", "Veículo.Atualizar", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 21, "Permissões", "Concessionária.Ler", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 22, "Permissões", "Concessionária.Inserir", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 23, "Permissões", "Concessionária.Atualizar", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 24, "Permissões", "Venda.Ler", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 25, "Permissões", "Cliente.Ler", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 26, "Permissões", "Cliente.Inserir", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 27, "Permissões", "Cliente.Atualizar", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 28, "Permissões", "Relatorio.Ler", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { 29, "Permissões", "Fabricante.Ler", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { 30, "Permissões", "Concessionária.Ler", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { 31, "Permissões", "Veículo.Ler", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { 32, "Permissões", "Cliente.Ler", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { 33, "Permissões", "Venda.Ler", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { 34, "Permissões", "Venda.Inserir", "341743f0-asd2–42de-afbf-59kmkkmk72cf6" },
                    { 35, "Permissões", "Fabricante.Ler", "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { 36, "Permissões", "Concessionária.Ler", "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { 37, "Permissões", "Veículo.Ler", "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { 38, "Permissões", "Cliente.Ler", "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { 39, "Permissões", "Venda.Ler", "fab4fac1-c546-41de-aebc-a14da6895711" },
                    { 40, "Permissões", "Venda.Inserir", "fab4fac1-c546-41de-aebc-a14da6895711" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 1,
                column: "ProtocoloVenda",
                value: "CF122B6A-9946-49E8-A");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 2,
                column: "ProtocoloVenda",
                value: "A46C5E56-AE03-43E0-B");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 3,
                column: "ProtocoloVenda",
                value: "09048A2D-3ECA-4CD8-8");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 4,
                column: "ProtocoloVenda",
                value: "00CBAE7C-6763-4AC5-9");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 5,
                column: "ProtocoloVenda",
                value: "82E927D2-3861-4EE2-A");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 6,
                column: "ProtocoloVenda",
                value: "44D7901F-0F9D-4F5D-A");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 7,
                column: "ProtocoloVenda",
                value: "75EF1BC2-03A4-455C-8");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 8,
                column: "ProtocoloVenda",
                value: "02E52FE5-6F20-4893-8");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 9,
                column: "ProtocoloVenda",
                value: "AFFD5F09-7266-4D05-B");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 10,
                column: "ProtocoloVenda",
                value: "528ADF11-0867-4C69-B");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 11,
                column: "ProtocoloVenda",
                value: "65CB24B0-33F2-4F55-8");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 12,
                column: "ProtocoloVenda",
                value: "7FD9663B-AB7D-4EB3-9");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 13,
                column: "ProtocoloVenda",
                value: "7E5D30AA-24FC-46DE-B");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 14,
                column: "ProtocoloVenda",
                value: "95684945-C254-421D-9");

            migrationBuilder.UpdateData(
                table: "Vendas",
                keyColumn: "VendaId",
                keyValue: 15,
                column: "ProtocoloVenda",
                value: "06A001F0-CC76-4033-A");
        }
    }
}
