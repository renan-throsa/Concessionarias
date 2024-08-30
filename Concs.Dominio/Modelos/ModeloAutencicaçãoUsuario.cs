namespace Concs.Dominio.Modelos
{
    public class ModeloAutencicaçãoUsuario
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool LembrasSe { get; set; } = false;
    }
}
