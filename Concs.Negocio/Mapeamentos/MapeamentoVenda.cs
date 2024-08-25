using AutoMapper;
using Concs.Dominio.Entidades;
using Concs.Dominio.Modelos;

namespace Concs.Negocio.Mapeamentos
{
    public class MapeamentoVenda : Profile
    {
        public MapeamentoVenda()
        {
            CreateMap<Venda, ModeloConsultaVenda>()
                .ForMember(dest => dest.VendaId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Cliente.Nome))
                .ForMember(dest => dest.Veiculo, opt => opt.MapFrom(src => src.Veiculo.Modelo))
                .ForMember(dest => dest.Concessionaria, opt => opt.MapFrom(src => src.Concessionaria.Nome))
                .ReverseMap();

            CreateMap<Venda, ModeloVisualizaçãoVenda>()
                .ForMember(dest => dest.VendaId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();


            CreateMap<Venda, ModeloInserçãoVenda>().ReverseMap();
        }
    }
}
