using Concs.Dominio.Entidades;
using FluentValidation;

namespace Concs.Negocio.Validações
{
    internal sealed class ValidadorDeVeiculo : AbstractValidator<Veiculo>
    {
        private readonly int anoAtual = DateTime.Today.Year;
        public ValidadorDeVeiculo()
        {
            RuleFor(x => x.Modelo).NotEmpty().MaximumLength(100);
            RuleFor(x => x.AnoFabricacao).InclusiveBetween(1886, anoAtual);
            RuleFor(x => x.Preco).NotEmpty().GreaterThan(0);
            RuleFor(x => x.FabricanteId).GreaterThanOrEqualTo(1);
            RuleFor(x => x.TipoVeiculoId).InclusiveBetween(1, 3);
            RuleFor(x => x.Descricao).MaximumLength(500);
        }
    }
}
