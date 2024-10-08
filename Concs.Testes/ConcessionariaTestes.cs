﻿using AutoMapper;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Mapeamentos;
using Concs.Negocio.Seviços;
using Concs.Testes.Utilidades;
using Moq;
using Xunit;

namespace Concs.Testes
{
    public class ConcessionariaTestes
    {
        private readonly Mock<IRepositorioConcessionária> _repositorioConcessionariaMock;
        private readonly Mock<IRepositorioVenda> _repositorioVendaMock;
        private readonly Mock<ICacheamento> _cacheamentoMock;
        private readonly ServiçoConcessionária _serviçoConcessionaria;
        private readonly IMapper _mapper;

        public ConcessionariaTestes()
        {
            _repositorioConcessionariaMock = new Mock<IRepositorioConcessionária>();
            _repositorioVendaMock = new Mock<IRepositorioVenda>();
            _cacheamentoMock = new Mock<ICacheamento>();
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MapeamentoConcessionária())).CreateMapper();
            _serviçoConcessionaria = new ServiçoConcessionária(_mapper, _repositorioConcessionariaMock.Object, _repositorioVendaMock.Object, _cacheamentoMock.Object);
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
        public async Task InsercaoComErroPorCausaDoNomeDuplicado()
        {
            var concecionaria = Dados.Concessionarias().First();

            _repositorioConcessionariaMock.Setup(x => x.NomeCadastrado(concecionaria.Nome)).ReturnsAsync(true);

            var modelo = new ModeloInserçãoConcessionária
            {
                Nome = concecionaria.Nome,
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

        [Fact]
        public async Task ExclusãoComErroPorCausaDeRelacionamentoComVenda()
        {
            var venda = Dados.Vendas().First();
            var concessionaria = Dados.Concessionarias().Where(x => x.Id == venda.Id).First();

            _repositorioConcessionariaMock.Setup(x => x.GetByIdAsync(concessionaria.Id, true)).ReturnsAsync(concessionaria);
            _repositorioVendaMock.Setup(x => x.vendaComConcessionária(concessionaria.Id)).ReturnsAsync(true);

            var resultado = await _serviçoConcessionaria.Remove(concessionaria.Id);

            Assert.False(resultado.IsValid);
        }
    }
}
