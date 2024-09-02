namespace Concs.Dominio.Modelos
{
    public class ModeloVisualizaçãoCliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
                

        public string CPFFormatado
        {
            get { return CPF.Substring(0, 3) + "." + CPF.Substring(3, 3) + "." + CPF.Substring(6, 3) + "-" + CPF.Substring(9, 2); }
        }

    }
}
