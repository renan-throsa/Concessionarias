namespace Concs.Dominio.Entidades
{
    public class Relatorio
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public decimal TotalVendas { get; set; }

        public List<Dado> VendasPorTipoDeveiculo { get; set; }
        public List<Dado> VendasPorFabricante { get; set; }
        public List<Dado> DesempenhoPorConcessionaria { get; set; }

    }
    public class Dado
    {
        public string Chave { get; set; }
        public decimal Valor { get; set; }
    }
}
