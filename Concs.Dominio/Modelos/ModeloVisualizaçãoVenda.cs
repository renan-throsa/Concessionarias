using Concs.Dominio.Entidades;

namespace Concs.Dominio.Modelos
{
    public class ModeloVisualizaçãoVenda
    {
        public int VendaId { get; set; }
        public int VeiculoId { get; set; }
        public int ConcessionariaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal PrecoVenda { get; set; }
        public string ProtocoloVenda { get; set; }

        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
        public Entidades.Concessionaria Concessionaria { get; set; }
    }
}
