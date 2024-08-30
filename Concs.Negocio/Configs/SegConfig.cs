namespace Concs.Negocio.Configs
{
    public class SegConfig
    {
        public string Segredo { get; set; } = string.Empty;
        public string Emissor { get; set; } = string.Empty;
        public string Audiencia { get; set; } = string.Empty;
        public int TempodeExpiraçãoEmHoras { get; set; }
        public int MaximoDeTentativasFalhas { get; set; }
    }
}
