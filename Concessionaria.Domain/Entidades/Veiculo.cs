namespace Concessionarias.Dominio.Entidades
{
    public class Veiculo : EntidadeBase
    {        
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
