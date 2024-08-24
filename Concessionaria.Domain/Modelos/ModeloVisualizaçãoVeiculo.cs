using Concessionarias.Dominio.Entidades;
namespace Concessionarias.Dominio.Modelos
{
    public class ModeloVisualizaçãoVeiculo
    {
        public int VeiculoId { get; set; }
        public int FabricanteId { get; set; }
        public int TipoVeiculoId { get; set; }

        public string Modelo { get; set; }

        public int AnoFabricacao { get; set; }

        public decimal Preco { get; set; }

        public string Descricao { get; set; }

        public TipoVeiculo TipoVeiculo { get; set; }
        public Fabricante Fabricante { get; set; }
    }
}
