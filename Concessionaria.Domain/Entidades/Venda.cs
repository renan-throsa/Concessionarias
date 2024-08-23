namespace Concessionarias.Dominio.Entidades
{
    public class Venda : EntidadeBase
    {
        public int VeiculoId { get; set; }
        public int ConcessionariaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal PrecoVenda { get; set; }
        public string ProtocoloVenda { get; set; }

        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
        public Concessionaria Concessionaria { get; set; }
    }
}
