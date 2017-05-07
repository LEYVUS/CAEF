using System.Collections.Generic;
using CAEF.Models.Entities.FIAD;

namespace CAEF.Repositorios
{
    public interface IUsuarioFIADRepositorio
    {
        IEnumerable<UsuarioFIAD> ObtenerUsuarios();
        UsuarioFIAD BuscarPorCorreo(string correo);
    }
}