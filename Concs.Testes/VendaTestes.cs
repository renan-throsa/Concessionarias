using AutoMapper;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Mapeamentos;
using Concs.Negocio.Seviços;
using Concs.Testes.Utilidades;
using Moq;
using Xunit;

namespace Concs.Testes
{
    public class VendaTestes
    {
        private readonly Mock<IRepositorioVenda> _repositorioVendaMock;
        private readonly Mock<IRepositorioVeiculo> _repositorioVeiculoMock;
        private readonly Mock<IRepositorioCliente> _repositorioClienteMock;
        private readonly Mock<ICacheamento> _cacheamentoMock;
        private readonly ServiçoVenda _serviçoVenda;
        private readonly IMapper _mapper;

        public VendaTestes()
        {
            _repositorioVendaMock = new Mock<IRepositorioVenda>();
            _repositorioVeiculoMock = new Mock<IRepositorioVeiculo>();
            _repositorioClienteMock = new Mock<IRepositorioCliente>();
            _cacheamentoMock = new Mock<ICacheamento>();
            _mapper = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapeamentoVenda());
                    mc.AddProfile(new MapeamentoCliente());

                }
            ).CreateMapper();

            _serviçoVenda = new ServiçoVenda(_mapper, _repositorioVendaMock.Object, _repositorioVeiculoMock.Object, _cacheamentoMock.Object, _repositorioClienteMock.Object);
        }

        [Fact]
        public async Task InsercaoComSucesso()
        {
            Veiculo veiculo = Dados.Veiculos().First(x => x.Id == 8);
            ModeloInserçãoCliente cliente = new ModeloInserçãoCliente() { Nome = "Esther Vitória Peixoto", CPF = "848.076.188-14", Telefone = "(81) 98795-2530" };

            _repositorioVeiculoMock.Setup(r => r.GetByIdAsync(veiculo.Id, false)).ReturnsAsync(veiculo);
            _repositorioClienteMock.Setup(r => r.CPFCadastrado(cliente.CPF)).ReturnsAsync(false);

            var modelo = new ModeloInserçãoVenda
            {
                VeiculoId = veiculo.Id,
                ConcessionariaId = 8,
                DataVenda = DateTime.Today,
                PrecoVenda = 62000.00m,
                Cliente = cliente,
            };

            var resultado = await _serviçoVenda.Insert(modelo);

            Assert.True(resultado.IsValid);
        }

        [Fact]
        public async Task InsercaoComErroPorCausaDaData()
        {
            Veiculo veiculo = Dados.Veiculos().First(x => x.Id == 8);

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
            Veiculo veiculo = Dados.Veiculos().First(x => x.Id == 8);

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
