using Concs.Dominio.Modelos;

namespace Concs.Dominio.Interfaces
{
    public interface IServiçoUsuario
    {
        Task<ModeloResultadoDaOperação> Registrar(ModeloRegistroUsuario modeloInserçãoUsuario);
        Task<ModeloResultadoDaOperação> Autenticar(ModeloAutencicaçãoUsuario modeloConsultaUsuario);
    }
}
