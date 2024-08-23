using AutoMapper;
using Concessionarias.Dominio.Entidades;
using Concessionarias.Dominio.Interfaces;
using Concessionarias.Dominio.Modelos;
using Concessionarias.Negocio.Mapeamentos;
using Concessionarias.Negocio.Seviços;
using Moq;
using Xunit;

namespace Concessionarias.Testes
{
    public class VendaTestes
    {
        private readonly Mock<IRepositorioVenda> _repositorioVendaMock;
        private readonly Mock<IRepositorioVeiculo> _repositorioVeiculoMock;
        private readonly ServiçoVenda _serviçoVenda;
        private readonly IMapper _mapper;

        public VendaTestes()
        {
            _repositorioVendaMock = new Mock<IRepositorioVenda>();
            _repositorioVeiculoMock = new Mock<IRepositorioVeiculo>();

            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MapeamentoVenda())).CreateMapper();

            _serviçoVenda = new ServiçoVenda(_mapper, _repositorioVendaMock.Object, _repositorioVeiculoMock.Object);
        }

        [Fact]
        public async Task InsercaoComSucesso()
        {
            Veiculo veiculo = Utilidades.Veiculos().First(x => x.Id == 8);

            _repositorioVeiculoMock.Setup(r => r.GetByIdAsync(veiculo.Id, false)).ReturnsAsync(veiculo);

            var modelo = new ModeloInserçãoVenda
            {
                VeiculoId = veiculo.Id,
                ConcessionariaId = 8,
                ClienteId = 16,
                DataVenda = DateTime.Today,
                PrecoVenda = 62000.00m
            };

            var resultado = await _serviçoVenda.Insert(modelo);

            Assert.True(resultado.IsValid);
        }

        [Fact]
        public async Task InsercaoComErroPorCausaDaData()
        {
            Veiculo veiculo = Utilidades.Veiculos().First(x => x.Id == 8);

            _repositorioVeiculoMock.Setup(r => r.GetByIdAsync(veiculo.Id, false)).ReturnsAsync(veiculo);

            var modelo = new ModeloInserçãoVenda
            {
                VeiculoId = veiculo.Id,
                ConcessionariaId = 8,
                ClienteId = 16,
                DataVenda = DateTime.Today.AddDays(1),
                PrecoVenda = 62000.00m
            };

            var resultado = await _serviçoVenda.Insert(modelo);

            Assert.False(resultado.IsValid);
        }


        [Fact]
        public async Task InsercaoComErroPorCausaDoPreço()
        {
            Veiculo veiculo = Utilidades.Veiculos().First(x => x.Id == 8);

            _repositorioVeiculoMock.Setup(r => r.GetByIdAsync(veiculo.Id, false)).ReturnsAsync(veiculo);

            var modelo = new ModeloInserçãoVenda
            {
                VeiculoId = veiculo.Id,
                ConcessionariaId = 8,
                ClienteId = 16,
                DataVenda = DateTime.Today,
                PrecoVenda = 69000.00m
            };
            var resultado = await _serviçoVenda.Insert(modelo);

            Assert.False(resultado.IsValid);
        }


    }
}
