using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concs.Dados.Configs
{
    public sealed class ClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
        {
            var claims = new List<IdentityUserClaim<string>>()
            {
                //Administrador
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Fabricante.Ler"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Fabricante.Inserir"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Fabricante.Atualizar"},

                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Veículo.Ler"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Veículo.Inserir"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Veículo.Atualizar"},

                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Concessionária.Ler"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Concessionária.Inserir"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Concessionária.Atualizar"},

                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Venda.Ler"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Venda.Inserir"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Venda.Atualizar"},

                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Cliente.Ler"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Cliente.Inserir"},
                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Cliente.Atualizar"},

                new IdentityUserClaim<string>{ UserId="88ecdfcb-85b4-4b8a-969e-47a4d07701bb",ClaimType="Permissões",ClaimValue="Relatorio.Ler"},
                

                //Gerente
                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Fabricante.Ler"},

                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Veículo.Ler"},
                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Veículo.Inserir"},
                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Veículo.Atualizar"},

                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Concessionária.Ler"},
                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Concessionária.Inserir"},
                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Concessionária.Atualizar"},

                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Venda.Ler"},

                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Cliente.Ler"},
                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Cliente.Inserir"},
                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Cliente.Atualizar"},

                new IdentityUserClaim<string>{ UserId="02174cf0–9412–4cfe-afbf-59f706d72cf6",ClaimType="Permissões",ClaimValue="Relatorio.Ler"},

                //Vendedor
                new IdentityUserClaim<string>{ UserId="341743f0-asd2–42de-afbf-59kmkkmk72cf6",ClaimType="Permissões",ClaimValue="Fabricante.Ler"},
                new IdentityUserClaim<string>{ UserId="341743f0-asd2–42de-afbf-59kmkkmk72cf6",ClaimType="Permissões",ClaimValue="Concessionária.Ler"},
                new IdentityUserClaim<string>{ UserId="341743f0-asd2–42de-afbf-59kmkkmk72cf6",ClaimType="Permissões",ClaimValue="Veículo.Ler"},
                new IdentityUserClaim<string>{ UserId="341743f0-asd2–42de-afbf-59kmkkmk72cf6",ClaimType="Permissões",ClaimValue="Cliente.Ler"},
                new IdentityUserClaim<string>{ UserId="341743f0-asd2–42de-afbf-59kmkkmk72cf6",ClaimType="Permissões",ClaimValue="Venda.Ler"},
                new IdentityUserClaim<string>{ UserId="341743f0-asd2–42de-afbf-59kmkkmk72cf6",ClaimType="Permissões",ClaimValue="Venda.Inserir"},



                new IdentityUserClaim<string>{ UserId="fab4fac1-c546-41de-aebc-a14da6895711",ClaimType="Permissões",ClaimValue="Fabricante.Ler"},
                new IdentityUserClaim<string>{ UserId="fab4fac1-c546-41de-aebc-a14da6895711",ClaimType="Permissões",ClaimValue="Concessionária.Ler"},
                new IdentityUserClaim<string>{ UserId="fab4fac1-c546-41de-aebc-a14da6895711",ClaimType="Permissões",ClaimValue="Veículo.Ler"},
                new IdentityUserClaim<string>{ UserId="fab4fac1-c546-41de-aebc-a14da6895711",ClaimType="Permissões",ClaimValue="Cliente.Ler"},
                new IdentityUserClaim<string>{ UserId="fab4fac1-c546-41de-aebc-a14da6895711",ClaimType="Permissões",ClaimValue="Venda.Ler"},
                new IdentityUserClaim<string>{ UserId="fab4fac1-c546-41de-aebc-a14da6895711",ClaimType="Permissões",ClaimValue="Venda.Inserir"},

            };

            int aux = 1;
            for (int i = 0; i < claims.Count(); i++)
            {
                claims[i].Id = aux;
                aux++;
            }

            builder.HasData(claims);
        }
    }
}
