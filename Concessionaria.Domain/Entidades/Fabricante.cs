namespace Concessionaria.Dominio.Entidades
{
    public class Fabricante : EntidadeBase
    {
        public int FabricanteId { get; set; } 
        public string Nome { get; set; } 
        public string PaisOrigem { get; set; }
        public int AnoFundacao { get; set; } 
        public string Website { get; set; }
        public bool Ativo { get; set; }

    }
}
