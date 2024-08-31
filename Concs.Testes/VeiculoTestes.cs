using AutoMapper;
using Concs.Dominio.Entidades;
using Concs.Dominio.Interfaces;
using Concs.Dominio.Modelos;
using Concs.Negocio.Mapeamentos;
using Concs.Negocio.Seviços;
using Concs.Testes.Utilidades;
using Moq;
using System.Reflection;
using Xunit;

namespace Concs.Testes
{
    public class VeiculoTestes
    {
        private readonly Mock<IRepositorioVeiculo> _repositorioVeiculoMock;
        private readonly Mock<IRepositorioVenda> _repositorioVendaMock;
        private readonly Mock<ICacheamento> _cacheamentoMock;
        private readonly ServiçoVeiculo _serviçoVeiculo;
        private readonly IMapper _mapper;

        public VeiculoTestes()
        {
            _repositorioVeiculoMock = new Mock<IRepositorioVeiculo>();
            _repositorioVendaMock = new Mock<IRepositorioVenda>();
            _cacheamentoMock = new Mock<ICacheamento>();
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MapeamentoVeiculo())).CreateMapper();
            _serviçoVeiculo = new ServiçoVeiculo(_mapper, _repositorioVeiculoMock.Object, _repositorioVendaMock.Object, _cacheamentoMock.Object);
        }

        [Fact]
        public async Task InsercaoComSucesso()
        {
            var modelo = new ModeloInserçãoVeiculo
            {
                FabricanteId = 1,
                TipoVeiculoId = 2,
                Modelo = "Sedan Luxo",
                AnoFabricacao = 2023,
                Preco = 75000.50m,
                Descricao = "Um sedan luxuoso com acabamento premium."
            };

            var resultado = await _serviçoVeiculo.Insert(modelo);

            Assert.True(resultado.IsValid);
        }

        [Fact]
        public async Task AtualizacaoComErro()
        {
            var modelo = new ModeloAtualizaçãoVeiculo
            {
                VeiculoId = 1,
                FabricanteId = 0,
                TipoVeiculoId = 0,
                Modelo = "Sedan Luxo",
                AnoFabricacao = 2023,
                Preco = 0,
                Descricao = ""
            };

            var resultado = await _serviçoVeiculo.Update(modelo);

            Assert.False(resultado.IsValid);
        }

        [Fact]
        public async Task ExclusãoComErro()
        {
            var venda  = Dados.Vendas().First();
            var veiculo = Dados.Veiculos().Where(x => x.Id == venda.VeiculoId).First();

            _repositorioVeiculoMock.Setup(r => r.GetByIdAsync(veiculo.Id, true)).ReturnsAsync(veiculo);
            _repositorioVendaMock.Setup(r => r.vendaComVeiculo(venda.VeiculoId)).ReturnsAsync(true);

            var resultado = await _serviçoVeiculo.Remove(veiculo.Id);

            Assert.False(resultado.IsValid);
        }

        [Fact]
        public async Task InsercaoComErroPorCausaDaData()
        {
            var modelo = new ModeloInserçãoVeiculo
            {
                FabricanteId = 1,
                TipoVeiculoId = 2,
                Modelo = "Sedan Luxo",
                AnoFabricacao = DateTime.Today.AddYears(1).Year,
                Preco = 75000.50m,
                Descricao = "Um sedan luxuoso com acabamento premium."
            };
            var resultado = await _serviçoVeiculo.Insert(modelo);

            Assert.False(resultado.IsValid);
        }


        [Fact]
        public async Task InsercaoComErroPorCausaDoNModelo()
        {
            var modelo = new ModeloInserçãoVeiculo
            {
                FabricanteId = 1,
                TipoVeiculoId = 2,
                Modelo = "Sedan Luxo OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ",
                AnoFabricacao = 2023,
                Preco = 75000.50m,
                Descricao = "Um sedan luxuoso com acabamento premium."
            };
            var resultado = await _serviçoVeiculo.Insert(modelo);

            Assert.False(resultado.IsValid);
        }


        [Fact]
        public async Task InsercaoComErroPorCausaDaDescrição()
        {
            var modelo = new ModeloInserçãoVeiculo
            {
                FabricanteId = 1,
                TipoVeiculoId = 2,
                Modelo = "Sedan Luxo",
                AnoFabricacao = DateTime.Today.AddYears(1).Year,
                Preco = 75000.50m,
                Descricao = "Um sedan luxuoso com acabamento premium " +
                "OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ " +
                "OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ" +
                "OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ" +
                "OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ" +
                "OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ" +
                "OKRUCZQSAJLQOCQLRKCYBSEFUEBINAVVHPZXXEFTPYRYULFUFNPXFIUCXTNVSANRPVKSPEEXXEMDPVQQOISLBABMCPVHJLKGHYJZ"
            };

            var resultado = await _serviçoVeiculo.Insert(modelo);

            Assert.False(resultado.IsValid);
        }
    }
}
