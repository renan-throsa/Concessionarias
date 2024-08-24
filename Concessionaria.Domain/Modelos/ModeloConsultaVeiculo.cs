namespace Concessionarias.Dominio.Modelos
{
    public class ModeloConsultaVeiculo
    {
        public int VeiculoId { get; set; }
        public int FabricanteId { get; set; }
        public int TipoVeiculoId { get; set; }

        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public decimal Preco { get; set; }

        public string TipoVeiculo { get; set; }
        public string Fabricante { get; set; }
    }
}
