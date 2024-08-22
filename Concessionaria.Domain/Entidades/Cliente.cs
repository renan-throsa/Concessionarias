namespace Concessionaria.Dominio.Entidades
{
    public class Cliente : EntidadeBase
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; }
    }
}
