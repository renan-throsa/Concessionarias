using System.Globalization;

namespace Concs.Dominio.Modelos
{
    public class ModeloConsultaVeiculo
    {
        public int VeiculoId { get; set; }
        public int FabricanteId { get; set; }
        public int TipoVeiculoId { get; set; }

        public string Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public decimal Preco { get; set; }

        public string TipoVeiculo { get; set; }
        public string Fabricante { get; set; }


        public string Resumo
        {
            get { return $"{Modelo} - {Fabricante} - {Preco.ToString("C", new CultureInfo("pt-BR"))}"; }

        }

    }
}
