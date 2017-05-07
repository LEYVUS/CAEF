using System.Collections.Generic;
using CAEF.Models.Entities.UABC;

namespace CAEF.Repositorios
{
    public interface IUsuarioUABCRepository
    {
        List<UsuarioUABC> ObtenerUsuarios();
        UsuarioUABC BuscarPorCorreo(string correo);
    }
}