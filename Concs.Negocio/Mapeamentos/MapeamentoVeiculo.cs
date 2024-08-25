using AutoMapper;
using Concs.Dominio.Entidades;
using Concs.Dominio.Modelos;

namespace Concs.Negocio.Mapeamentos
{
    public class MapeamentoVeiculo : Profile
    {
        public MapeamentoVeiculo()
        {
            CreateMap<Veiculo, ModeloConsultaVeiculo>()
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoVeiculo, opt => opt.MapFrom(src => src.TipoVeiculo.Tipo))
                .ForMember(dest => dest.Fabricante, opt => opt.MapFrom(src => src.Fabricante.Nome))
                .ReverseMap();

            CreateMap<Veiculo, ModeloVisualizaçãoVeiculo>()
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();


            CreateMap<Veiculo, ModeloInserçãoVeiculo>().ReverseMap();
        }
    }
}
