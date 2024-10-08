﻿using AutoMapper;
using Concs.Dominio.Interfaces;
using Concs.Negocio.Seviços;
using Concs.Negocio.Mapeamentos;
using Moq;
using Xunit;
using Concs.Dominio.Modelos;
using Concs.Testes.Utilidades;

namespace Concs.Testes
{
    public class FabricanteTestes
    {
        private readonly Mock<IRepositorioFabricante> _repositorioFabricanteMock;
        private readonly Mock<IRepositorioVeiculo> _repositorioVeiculoMock;
        private readonly Mock<ICacheamento> _cacheamentoMock;
        private readonly ServiçoFabricante _serviçoFabricante;
        private readonly IMapper _mapper;

        public FabricanteTestes()
        {
            _repositorioFabricanteMock = new Mock<IRepositorioFabricante>();
            _repositorioVeiculoMock = new Mock<IRepositorioVeiculo>();
            _cacheamentoMock = new Mock<ICacheamento>();
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MapeamentoFabricante())).CreateMapper();
            _serviçoFabricante = new ServiçoFabricante(_mapper, _repositorioFabricanteMock.Object, _cacheamentoMock.Object, _repositorioVeiculoMock.Object);
        }

        [Fact]
        public async Task InsercaoComSucesso01()
        {
            var fabricante = new ModeloInserçãoFabricante
            {
                Nome = "Acme Corporation",
                PaisOrigem = "Estados Unidos",
                AnoFundacao = 1950,
                Website = "https://www.acmecorp.com"
            };
            var resultado = await _serviçoFabricante.Insert(fabricante);

            Assert.True(resultado.IsValid);
        }

        [Fact]
        public async Task InsercaoComSucesso02()
        {
            var fabricante = new ModeloInserçãoFabricante
            {
                Nome = "Les Chapolins",
                PaisOrigem = "Mexico",
                AnoFundacao = 1980,
                Website = "www.chapolins.mx"
            };
            var resultado = await _serviçoFabricante.Insert(fabricante);

            Assert.True(resultado.IsValid);
        }

        [Fact]
        public async Task InsercaoComErroPorCausaDaData()
        {
            var fabricante = new ModeloInserçãoFabricante
            {
                Nome = "Acme Corporation",
                PaisOrigem = "Estados Unidos",
                AnoFundacao = DateTime.Today.AddYears(1).Year,
                Website = "https://www.acmecorp.com"
            };
            var resultado = await _serviçoFabricante.Insert(fabricante);

            Assert.False(resultado.IsValid);
        }


        [Fact]
        public async Task InsercaoComErroPorCausaDoNome()
        {
            var fabricante = new ModeloInserçãoFabricante
            {
                Nome = "Acme Weyland Yutani Corporation LTDA INC - Inovação Sustentável em Tecnologia de Engenharia e Manufatura",
                PaisOrigem = "Estados Unidos",
                AnoFundacao = 1950,
                Website = "https://www.acmecorp.com"
            };
            var resultado = await _serviçoFabricante.Insert(fabricante);

            Assert.False(resultado.IsValid);
        }

        [Fact]
        public async Task InsercaoComErroPorCausaDoNomeDuplicado()
        {
            var fabricante = Dados.Fabricantes().First();

            _repositorioFabricanteMock.Setup(x => x.NomeCadastrado(fabricante.Nome)).ReturnsAsync(true);

            var modelo = new ModeloInserçãoFabricante
            {
                Nome = fabricante.Nome,
                PaisOrigem = "Estados Unidos",
                AnoFundacao = 1950,
                Website = "https://www.acmecorp.com"
            };
            var resultado = await _serviçoFabricante.Insert(modelo);

            Assert.False(resultado.IsValid);
        }

        [Fact]
        public async Task ExclusãoComErro()
        {
            var fabricante = Dados.Fabricantes().First();
            var veiculo = Dados.Veiculos().Where(x => x.FabricanteId == fabricante.Id).First();

            _repositorioFabricanteMock.Setup(r => r.GetByIdAsync(fabricante.Id, true)).ReturnsAsync(fabricante);
            _repositorioVeiculoMock.Setup(r => r.veiculoComFabricanteCom(fabricante.Id)).ReturnsAsync(true);

            var resultado = await _serviçoFabricante.Remove(fabricante.Id);

            Assert.False(resultado.IsValid);
        }


        [Fact]
        public async Task InsercaoComErroPorCausaDoPais()
        {
            var fabricante = new ModeloInserçãoFabricante
            {
                Nome = "Acme Corporation",
                PaisOrigem = "Pais do Reino Unido da Grã-Bretanha e Irlanda do Norte",
                AnoFundacao = 1950,
                Website = "https://www.acmecorp.com"
            };
            var resultado = await _serviçoFabricante.Insert(fabricante);

            Assert.False(resultado.IsValid);
        }


    }
}
