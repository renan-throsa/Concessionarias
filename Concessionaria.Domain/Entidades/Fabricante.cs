namespace Concessionarias.Dominio.Entidades
{
    public class Fabricante : EntidadeBase
    {        
        public string Nome { get; set; } 
        public string PaisOrigem { get; set; }
        public int AnoFundacao { get; set; } 
        public string Website { get; set; }

    }
}
