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
        bool UsuarioExiste(Usuario usuario);
        bool UsuarioDuplicado(Usuario usuario);
        Task<bool> GuardarCambios();
    }
}