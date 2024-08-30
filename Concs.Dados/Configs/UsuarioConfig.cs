using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Concs.Dados.Configs
{
    internal sealed class UsuarioConfig : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var adm = new IdentityUser()
            {

                Id = "88ecdfcb-85b4-4b8a-969e-47a4d07701bb",
                UserName = "Manoel Hugo Carvalho",
                Email = "manoelhugocarvalho@demasi.com.br",
                NormalizedUserName = "manoelhugocarvalho@demasi.com.br".ToUpper(),
                NormalizedEmail = "manoelhugocarvalho@demasi.com.br".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "(79) 99598-4047",
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
            };


            adm.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adm, "3oACF@Ycqz$L3eRJ");
            builder.HasData(adm);

            var gerente = new IdentityUser()
            {

                Id = "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                UserName = "Tânia Patrícia Caroline Bernardes",
                NormalizedUserName = "Tânia Patrícia Caroline Bernardes".ToUpper(),
                Email = "taniapatriciabernardes@agen-pegeuot.com.br",
                NormalizedEmail = "taniapatriciabernardes@agen-pegeuot.com.br".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "(92) 99115-2024",
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
            };

            gerente.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(gerente, "6znFLR7H?kbYdqFm");
            builder.HasData(gerente);


            var vendedor01 = new IdentityUser()
            {

                Id = "341743f0-asd2–42de-afbf-59kmkkmk72cf6",
                UserName = "Thales Juan Pereira",
                NormalizedUserName = "Thales Juan Pereira".ToUpper(),
                Email = "thales.juan.pereira@santosferreira.adv.br",
                NormalizedEmail = "thales.juan.pereira@santosferreira.adv.br".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "(98) 99749-3175",
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
            };

            vendedor01.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(adm, "bh3D@EKY@$!RpXdf");
            builder.HasData(vendedor01);

            var vendedor02 = new IdentityUser()
            {

                Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                UserName = "Esther Manuela Natália Nogueira",
                NormalizedUserName = "Esther Manuela Natália Nogueira".ToUpper(),
                Email = "esther-nogueira86@edu.uniso.br",
                NormalizedEmail = "esther-nogueira86@edu.uniso.br".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "(98) 98876-8556",
                PhoneNumberConfirmed = true,
                LockoutEnabled = true,
            };

            vendedor02.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(vendedor02, "g8eSnc3?n&Y95NyQ");

            builder.HasData(vendedor02);

        }
    }
}
