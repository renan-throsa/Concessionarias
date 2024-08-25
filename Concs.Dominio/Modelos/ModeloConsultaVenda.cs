namespace Concs.Dominio.Modelos
{
    public class ModeloConsultaVenda
    {
        public int VendaId { get; set; }
        public int VeiculoId { get; set; }
        public int ConcessionariaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal PrecoVenda { get; set; }
        public string ProtocoloVenda { get; set; }

        public string Cliente { get; set; }
        public string Veiculo { get; set; }
        public string Concessionaria { get; set; }
    }
}
