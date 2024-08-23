using Concessionarias.Dominio.Entidades;
using FluentValidation;

namespace Concessionarias.Negocio.Validações
{
    internal sealed class ValidadorDeFabricante : AbstractValidator<Fabricante>
    {
        private readonly int anoPassado = DateTime.Today.Year - 1;
        public ValidadorDeFabricante()
        {
            RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
            RuleFor(x => x.PaisOrigem).NotEmpty().MaximumLength(50);
            RuleFor(x => x.AnoFundacao).InclusiveBetween(1886, anoPassado);
            RuleFor(x => x.Website).Matches(@"^(http|https)://[a-zA-Z0-9.-]+(\.[a-zA-Z]{2,4})(:[0-9]+)?(/.*)?$");
        }
    }
}
