using CAEF.Models.Entidades.FIAD;
using System.Collections.Generic;


namespace CAEF.Repositorios
{
    public interface IUsuarioFIADRepositorio
    {
        
        Usuario BuscarPorCorreo(string correo);
    }
}