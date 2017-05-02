using System.Collections.Generic;
using CAEF.Models.Entities.CAEF;
using System.Threading.Tasks;

namespace CAEF.Models.Repositories
{
    public interface ICAEFRepository
    {
        IEnumerable<Usuario> ObtenerUsuarios();
        IEnumerable<Rol> ObtenerRoles();
        IEnumerable<Carrera> ObtenerCarreras();
        IEnumerable<Materia> ObtenerMaterias();
        IEnumerable<SubtipoExamen> ObtenerSubtiposExamen();
        IEnumerable<TipoExamen> ObtenerTiposExamen();
        void AgregarUsuario(Usuario usuario);
        int AgregarActaDocente(SolicitudDocente acta);
        void AgregarActaAdmin(SolicitudAdmin acta);
        void AgregarSolicitudAlumno(IEnumerable<SolicitudAlumno> solicitudes);
        int CuentaSolicitudes();
        void EditarUsuario(Usuario usuario);
        void BorrarUsuario(Usuario usuario);
        bool UsuarioExiste(string Correo);
        Usuario UsuarioAutenticado(string username);
        bool UsuarioDuplicado(string Correo);
        Task<bool> GuardarCambios();
    }
}