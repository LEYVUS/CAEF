using CAEF.Models.Entidades.UABC;
using System.Collections.Generic;


namespace CAEF.Repositorios
{
    public interface IUsuarioUABCRepositorio
    {

        Usuario BuscarPorCorreo(string correo);
    }
}