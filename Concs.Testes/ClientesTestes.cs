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
    public class ClientesTestes
    {
        private readonly Mock<IRepositorioCliente> _repositorioClienteMock;
        private readonly Mock<IRepositorioVenda> _repositorioVendaMock;
        private readonly Mock<ICacheamento> _cacheamentoMock;
        private readonly IMapper _mapper;
        private readonly ServiçoCliente _serviçoCliente;

        public ClientesTestes()
        {
            _repositorioClienteMock = new Mock<IRepositorioCliente>();
            _repositorioVendaMock = new Mock<IRepositorioVenda>();
            _cacheamentoMock = new Mock<ICacheamento>();
            _mapper = new MapperConfiguration(mc => mc.AddProfile(new MapeamentoCliente())).CreateMapper();
            _serviçoCliente = new ServiçoCliente(_mapper, _repositorioClienteMock.Object, _repositorioVendaMock.Object, _cacheamentoMock.Object);
        }


        [Fact]
        public async Task InsercaoComErroPorCausaDoCpfDuplicado()
        {
            var cliente = Dados.Clientes().First();

            _repositorioClienteMock.Setup(x => x.CPFCadastrado(cliente.CPF)).ReturnsAsync(true);

            var modelo = new ModeloInserçãoCliente
            {
                Nome = "Márcio Yuri João Gomes",
                CPF = cliente.CPF,
                Telefone = "(11) 98765-4321"
            };

            var resultado = await _serviçoCliente.Insert(modelo);

            Assert.False(resultado.IsValid);
        }

        [Fact]
        public async Task ExclusãoComErroPorCausaDeRelacionamentoComVenda()
        {
            var venda = Dados.Vendas().First();
            var cliente = Dados.Clientes().Where(x => x.Id == venda.Id).First();

            _repositorioClienteMock.Setup(x => x.GetByIdAsync(cliente.Id, true)).ReturnsAsync(cliente);
            _repositorioVendaMock.Setup(x => x.vendaComCliente(cliente.Id)).ReturnsAsync(true);

            var resultado = await _serviçoCliente.Remove(cliente.Id);

            Assert.False(resultado.IsValid);
        }

    }
}
