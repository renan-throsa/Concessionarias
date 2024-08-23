using Concessionarias.Dominio.Entidades;

namespace Concessionarias.Testes
{
    public static class Utilidades
    {
        public static List<Cliente> Clientes() => new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "Maria Silva", CPF = "12345678901", Telefone = "(11) 98765-4321",Ativo = true },
            new Cliente { Id = 2, Nome = "João Santos", CPF = "98765432109", Telefone = "(21) 5555-1234",Ativo = true },
            new Cliente { Id = 3, Nome = "Carlos Oliveira", CPF = "78912345602", Telefone = "(31) 98765-9876",Ativo = true },
            new Cliente { Id = 4, Nome = "Ana Rodrigues", CPF = "65432198703", Telefone = "(41) 5555-5678" , Ativo = true},
            new Cliente { Id = 5, Nome = "Fernanda Lima", CPF = "45678912304", Telefone = "(51) 98765-4321" , Ativo = true},
            new Cliente { Id = 6, Nome = "Rafael Souza", CPF = "32165498705", Telefone = "(21) 5555-6789" , Ativo = true},
            new Cliente { Id = 7, Nome = "Lúcia Santos", CPF = "65498732106", Telefone = "(31) 98765-1234" , Ativo = true},
            new Cliente { Id = 8, Nome = "Pedro Alves", CPF = "98732165407", Telefone = "(41) 5555-2345" , Ativo = true},
            new Cliente { Id = 9, Nome = "Mariana Oliveira", CPF = "78945612308", Telefone = "(51) 98765-5678" , Ativo = true},
            new Cliente { Id = 10, Nome = "Lucas Rodrigues", CPF = "98732165409", Telefone = "(21) 5555-7890" , Ativo = true},
            new Cliente { Id = 11, Nome = "Isabela Almeida", CPF = "65478932110", Telefone = "(31) 98765-2345" , Ativo = true},
            new Cliente { Id = 12, Nome = "Gustavo Lima", CPF = "98765432111", Telefone = "(41) 5555-3456" , Ativo = true},
            new Cliente { Id = 13, Nome = "Larissa Costa", CPF = "78912345612", Telefone = "(51) 98765-6789" , Ativo = true},
            new Cliente { Id = 14, Nome = "Ricardo Santos", CPF = "98765432113", Telefone = "(21) 5555-8901" , Ativo = true},
            new Cliente { Id = 15, Nome = "Camila Alves", CPF = "65498732114", Telefone = "(31) 98765-3456" , Ativo = true},
            new Cliente { Id = 16, Nome = "Fábio Lima", CPF = "98732165415", Telefone = "(41) 5555-4567" , Ativo = true}
        };

        public static List<Veiculo> Veiculos() => new List<Veiculo>
        {
            new Veiculo
            {
                Id = 1,
                FabricanteId = 1,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "Sedan",
                AnoFabricacao = 2022,
                Preco = 55000.00m,
                Descricao = "Veículo confortável e econômico.",
                Ativo = true,

            },
            new Veiculo
            {
                Id = 2,
                FabricanteId = 2,
                TipoVeiculoId = (int)TipoVeiculoEnum.Moto,
                Modelo = "Esportiva",
                AnoFabricacao = 2021,
                Preco = 12000.00m,
                Descricao = "Moto ágil e potente.",
                Ativo = true,

            },
            new Veiculo
            {
                Id = 3,
                FabricanteId = 3,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "Sedan",
                AnoFabricacao = 2022,
                Preco = 45000.00m,
                Descricao = "Um carro confortável e econômico.",
                Ativo = true,
            },

            new Veiculo
            {
                Id = 4,
                FabricanteId = 3,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "SUV",
                AnoFabricacao = 2023,
                Preco = 55000.00m,
                Descricao = "Um SUV espaçoso e versátil.",
                Ativo = true,
            },

            new Veiculo
            {
                Id = 5,
                FabricanteId = 4,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "Hatchback",
                AnoFabricacao = 2024,
                Preco = 35000.00m,
                Descricao = "Um carro compacto e ágil.",
                Ativo = true,

            },

            new Veiculo
            {
                Id = 6,
                FabricanteId = 5,
                TipoVeiculoId = (int)TipoVeiculoEnum.Caminhão,
                Modelo = "Caminhonete",
                AnoFabricacao = 2023,
                Preco = 65000.00m,
                Descricao = "Uma caminhonete robusta e versátil.",
                Ativo = true,

            },
                new Veiculo
            {
                Id = 7,
                FabricanteId = 5,
                TipoVeiculoId = (int)TipoVeiculoEnum.Carro,
                Modelo = "Hatchback",
                AnoFabricacao = 2024,
                Preco = 35000.00m,
                Descricao = "Um carro compacto e ágil.",
                Ativo = true,
            },

            new Veiculo
            {
                Id = 8,
                FabricanteId = 6,
                TipoVeiculoId = (int)TipoVeiculoEnum.Caminhão,
                Modelo = "Caminhonete",
                AnoFabricacao = 2023,
                Preco = 65000.00m,
                Descricao = "Uma caminhonete robusta e versátil.",
                Ativo = true,
            },

        };

        public static List<Concessionaria> Concessionarias() => new List<Concessionaria>()
            {
                    new Concessionaria
                    {
                        Id = 1,
                        Nome = "Concessionária do Vale",
                        Endereco = "Rua das Flores, 123",
                        Cidade = "São Paulo",
                        Estado = "SP",
                        CEP = "01234567",
                        Telefone = "(11) 9876-5432",
                        Email = "contato@concessionariadovale.com.br",
                        CapacidadeMaximaVeiculos = 150
                    },
                    new Concessionaria
                    {
                        Id = 2,
                        Nome = "Auto Center ABC",
                        Endereco = "Av. das Palmeiras, 456",
                        Cidade = "Santo André",
                        Estado = "SP",
                        CEP = "09876543",
                        Telefone = "(11) 5555-1234",
                        Email = "vendas@autocenterabc.com",
                        CapacidadeMaximaVeiculos = 200
                    },
                    new Concessionaria
                    {
                        Id = 3,
                        Nome = "Auto Shop Zeta",
                        Endereco = "Rua dos Carros, 789",
                        Cidade = "Rio de Janeiro",
                        Estado = "RJ",
                        CEP = "20000123",
                        Telefone = "(21) 9876-5432",
                        Email = "vendas@autoshopzeta.com",
                        CapacidadeMaximaVeiculos = 180
                    },
                    new Concessionaria
                    {
                        Id = 4,
                        Nome = "Mega Motors",
                        Endereco = "Av. das Rodovias, 567",
                        Cidade = "Belo Horizonte",
                        Estado = "MG",
                        CEP = "30000456",
                        Telefone = "(31) 5555-1234",
                        Email = "contato@megamotors.com.br",
                        CapacidadeMaximaVeiculos = 220
                    },
                    new Concessionaria
                    {
                        Id = 5,
                        Nome = "Carros Express",
                        Endereco = "Av. das Velocidades, 789",
                        Cidade = "Curitiba",
                        Estado = "PR",
                        CEP = "80000789",
                        Telefone = "(41) 5555-6789",
                        Email = "vendas@carrosexpress.com",
                        CapacidadeMaximaVeiculos = 190
                    },
                    new Concessionaria
                    {
                        Id = 6,
                        Nome = "Auto Center XYZ",
                        Endereco = "Rua dos Motores, 567",
                        Cidade = "Porto Alegre",
                        Estado = "RS",
                        CEP = "90000123",
                        Telefone = "(51) 9876-2345",
                        Email = "contato@autocenterxyz.com",
                        CapacidadeMaximaVeiculos = 210
                    },
                    new Concessionaria
                    {
                        Id = 7,
                        Nome = "Carros Rápidos",
                        Endereco = "Av. das Acelerações, 789",
                        Cidade = "Florianópolis",
                        Estado = "SC",
                        CEP = "88000789",
                        Telefone = "(48) 9876-5678",
                        Email = "vendas@carrosrapidos.com",
                        CapacidadeMaximaVeiculos = 200
                    },
                    new Concessionaria
                    {
                        Id = 8,
                        Nome = "Auto Center ABCD",
                        Endereco = "Rua dos Motores, 123",
                        Cidade = "Recife",
                        Estado = "PE",
                        CEP = "50000123",
                        Telefone = "(81) 5555-6789",
                        Email = "contato@autocenterabcd.com",
                        CapacidadeMaximaVeiculos = 230
                    }
        };

        public static List<Fabricante> Fabricantes() => new List<Fabricante>
        {
            new Fabricante
            {
                Id = 1,
                Nome = "HyperCars",
                PaisOrigem = "Brasil",
                AnoFundacao = 1950,
                Website = "https://fabricantea.com"
            },
            new Fabricante
            {
                Id = 2,
                Nome = "EcoMotors",
                PaisOrigem = "Estados Unidos",
                AnoFundacao = 1925,
                Website = "https://fabricanteb.com"
            },
            new Fabricante
            {
                Id = 3,
                Nome = "SuperCarros",
                PaisOrigem = "Itália",
                AnoFundacao = 1960,
                Website = "https://www.supercarros.com"
            },
            new Fabricante
            {
                Id = 4,
                Nome = "TechMotors",
                PaisOrigem = "Japão",
                AnoFundacao = 1985,
                Website = "https://www.techmotors.co.jp"
            },
            new Fabricante
            {
                Id = 5,
                Nome = "TurboDrive",
                PaisOrigem = "Coreia do Sul",
                AnoFundacao = 2003,
                Website = "https://www.turbodrive"
            },
            new Fabricante
            {
                Id = 6,
                Nome = "Electric Wheels",
                PaisOrigem = "Holanda",
                AnoFundacao = 2006,
                Website = "https://www.wlectricwheels.co.ho"
            }
        };

    }
}
