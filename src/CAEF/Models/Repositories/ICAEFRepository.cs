using System.Collections.Generic;
using CAEF.Models.Entities.CAEF;
using System.Threading.Tasks;

namespace CAEF.Models.Repositories
{
    public interface ICAEFRepository
    {
        IEnumerable<Usuario> ObtenerUsuarios();
        IEnumerable<Rol> ObtenerRoles();
        void AgregarUsuario(Usuario usuario);
        void EditarUsuario(Usuario usuario);
        void BorrarUsuario(Usuario usuario);
        bool UsuarioExiste(string Correo);
        Usuario UsuarioAutenticado(string username);
        bool UsuarioDuplicado(string Correo);
        Task<bool> GuardarCambios();
    }
}