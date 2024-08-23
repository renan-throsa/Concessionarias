namespace Concessionarias.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
