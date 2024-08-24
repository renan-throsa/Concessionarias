using AutoMapper;
using Concessionarias.Dominio.Interfaces;
using Concessionarias.Negocio.Seviços;
using Concessionarias.Negocio.Mapeamentos;
using Moq;
using Xunit;
using Concessionarias.Dominio.Modelos;

namespace Concessionarias.Testes
{
    public class FabricanteTestes
    {
        private readonly Mock<IRepositorioFabricante> _repositorioFabricanteMock;
        private readonly ServiçoFabricante _serviçoFabricante;
        private readonly IMapper _mapper;

        public FabricanteTestes()
        {
            _repositorioFabricanteMock = new Mock<IRepositorioFabricante>();
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MapeamentoFabricante())).CreateMapper();
            _serviçoFabricante = new ServiçoFabricante(_mapper, _repositorioFabricanteMock.Object);
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
