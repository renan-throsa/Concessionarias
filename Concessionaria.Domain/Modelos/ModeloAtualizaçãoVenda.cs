namespace Concessionaria.Dominio.Modelos
{
    public class ModeloAtualizaçãoVenda
    {
        public int VendaId { get; set; }
        public int VeiculoId { get; set; }
        public int ConcessionariaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal PrecoVenda { get; set; }
        public string ProtocoloVenda { get; set; }
    }
}
