using AutoMapper;
using Concessionarias.Dominio.Interfaces;
using Concessionarias.Dominio.Modelos;
using Concessionarias.Negocio.Mapeamentos;
using Concessionarias.Negocio.Seviços;
using Moq;
using Xunit;

namespace Concessionarias.Testes
{
    public class ConcessionariaTestes
    {
        private readonly Mock<IRepositorioConcessionária> _repositorioConcessionariaMock;
        private readonly ServiçoConcessionária _serviçoConcessionaria;
        private readonly IMapper _mapper;

        public ConcessionariaTestes()
        {
            _repositorioConcessionariaMock = new Mock<IRepositorioConcessionária>();
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MapeamentoConcessionária())).CreateMapper();
            _serviçoConcessionaria = new ServiçoConcessionária(_mapper, _repositorioConcessionariaMock.Object);
        }

        [Fact]
        public async Task InsercaoComSucesso()
        {
            var modelo = new ModeloInserçãoConcessionária
            {
                Nome = "Concessionária Supercarros",
                Endereco = "Av. das Rodovias, 123",
                Cidade = "Metrópolis",
                Estado = "SP",
                CEP = "12345-678",
                Telefone = "(11) 9876-5432",
                Email = "contato@supercarros.com",
                CapacidadeMaximaVeiculos = 100
            };

            var resultado = await _serviçoConcessionaria.Insert(modelo);

            Assert.True(resultado.IsValid);
        }

        [Fact]
        public async Task InsercaoComErroPorCausaDaCapacidade()
        {
            var modelo = new ModeloInserçãoConcessionária
            {
                Nome = "Concessionária Supercarros",
                Endereco = "Av. das Rodovias, 123",
                Cidade = "Metrópolis",
                Estado = "SP",
                CEP = "12345-678",
                Telefone = "(11) 9876-5432",
                Email = "contato@supercarros.com",
                CapacidadeMaximaVeiculos = -100
            };

            var resultado = await _serviçoConcessionaria.Insert(modelo);

            Assert.False(resultado.IsValid);
        }


        [Fact]
        public async Task InsercaoComErroPorCausaDoNome()
        {
            var modelo = new ModeloInserçãoConcessionária
            {
                Nome = "Concessionária Supercarros OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ",
                Endereco = "Av. das Rodovias, 123",
                Cidade = "Metrópolis",
                Estado = "SP",
                CEP = "12345-678",
                Telefone = "(11) 9876-5432",
                Email = "contato@supercarros.com",
                CapacidadeMaximaVeiculos = 100
            };

            var resultado = await _serviçoConcessionaria.Insert(modelo);

            Assert.False(resultado.IsValid);
        }


        [Fact]
        public async Task InsercaoComErroPorCausaDoEndereço()
        {
            var modelo = new ModeloInserçãoConcessionária
            {
                Nome = "Concessionária Supercarros",
                Endereco = "Av. das Rodovias, 123 OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ" +
                " OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ" +
                " OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ",
                Cidade = "Metrópolis",
                Estado = "SP",
                CEP = "12345-678",
                Telefone = "(11) 9876-5432",
                Email = "contato@supercarros.com",
                CapacidadeMaximaVeiculos = 100
            };

            var resultado = await _serviçoConcessionaria.Insert(modelo);

            Assert.False(resultado.IsValid);
        }

        [Fact]
        public async Task InsercaoComErroPorCausaDoCep()
        {
            var modelo = new ModeloInserçãoConcessionária
            {
                Nome = "Concessionária Supercarros",
                Endereco = "Av. das Rodovias, 123",
                Cidade = "Metrópolis",
                Estado = "SP",
                CEP = "12345123678",
                Telefone = "(11) 9876-5432",
                Email = "contato@supercarros.com",
                CapacidadeMaximaVeiculos = 100
            };

            var resultado = await _serviçoConcessionaria.Insert(modelo);

            Assert.False(resultado.IsValid);
        }


        [Fact]
        public async Task InsercaoComErroPorCausaDoEmail()
        {
            var modelo = new ModeloInserçãoConcessionária
            {
                Nome = "Concessionária Supercarros",
                Endereco = "Av. das Rodovias, 123",
                Cidade = "Metrópolis",
                Estado = "SP",
                CEP = "12345123678",
                Telefone = "(11) 9876-5432",
                Email = "contato&supercarros.com",
                CapacidadeMaximaVeiculos = 100
            };

            var resultado = await _serviçoConcessionaria.Insert(modelo);

            Assert.False(resultado.IsValid);
        }
    }
}
