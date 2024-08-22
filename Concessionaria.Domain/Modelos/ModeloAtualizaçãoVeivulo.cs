﻿namespace Concessionaria.Dominio.Modelos
{
    public class ModeloAtualizaçãoVeivulo
    {
        public int VeiculoId { get; set; }
        public int FabricanteId { get; set; }
        public int TipoVeiculoId { get; set; }

        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }

    }
}
