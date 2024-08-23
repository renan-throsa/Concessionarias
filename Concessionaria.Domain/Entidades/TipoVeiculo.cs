namespace Concessionarias.Dominio.Entidades
{
    public class TipoVeiculo : EntidadeBase
    {        
        public string Tipo { get; set; }
    }

    public enum TipoVeiculoEnum
    {
        Carro = 1,
        Moto = 2,
        Caminhão = 3
    }
}
