using Concessionarias.Dominio.Entidades;
namespace Concessionarias.Dominio.Modelos
{
    public class ModeloConsultaConcessionária
    {
        public int ConcessionariaId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public int CapacidadeMaximaVeiculos { get; set; }


        public string Resumo
        {
            get { return $"{Nome} - {Cidade}"; }

        }
    }
}
