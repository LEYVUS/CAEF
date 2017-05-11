using System.Collections.Generic;
using CAEF.Models.Entities.CAEF;
using System.Threading.Tasks;

namespace CAEF.Models.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> ObtenerUsuarios();
        void AgregarUsuario(Usuario usuario);
        void EditarUsuario(Usuario usuario);
        void BorrarUsuario(Usuario usuario);
        bool UsuarioExiste(string Correo);
        Usuario UsuarioAutenticado(string Username);
        bool UsuarioDuplicado(string Correo);
        Task<bool> GuardarCambios();
    }
}
