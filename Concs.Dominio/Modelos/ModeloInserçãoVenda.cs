namespace Concs.Dominio.Modelos
{
    public class ModeloInserçãoVenda
    {
        public int VeiculoId { get; set; }
        public int ConcessionariaId { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal PrecoVenda { get; set; }

        public int ClienteId { get; set; }

        public ModeloInserçãoCliente Cliente { get; set; }
    }

}
