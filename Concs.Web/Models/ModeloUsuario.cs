namespace Concs.Web.Models
{
    public class ModeloUsuario
    {
        public string Id { get; init; }
        public string Nome { get; init; }
        public string Email { get; init; }
        public string Token { get; init; }

        public IEnumerable<string> Permissões { get; init; }       

        public bool Valido
        {
            get { return !string.IsNullOrEmpty(Id); }
        }

    }
}
