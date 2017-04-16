using CAEF.Models.Contexts;
using CAEF.Models.Entities.CAEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Models.Repositories
{
    public class CAEFRepository : ICAEFRepository
    {
        private CAEFContext _contextoCAEF;
        private UsuarioUABCContext _contextoUABC;

        public CAEFRepository(CAEFContext contextoCAEF, UsuarioUABCContext contextoUABC)
        {
            _contextoCAEF = contextoCAEF;
            _contextoUABC = contextoUABC;
        }

        public void AgregarUsuario(Usuario usuario)
        {
            // Al agregar usuario nuevo, solo se pide matrícula,
            // correo y rol, por lo tanto se tienen que extraer sus
            // nombres de la BD de UABC para poder mostrarlo en la lista
            // con toda la información correcta.
            var usuarioUABC = _contextoUABC.UsuariosUABC
                .Where(u => u.Matricula == usuario.Id)
                .FirstOrDefault();

            usuario.Nombre = usuarioUABC.Nombre;
            usuario.ApellidoP = usuarioUABC.ApellidoP;
            usuario.ApellidoM = usuarioUABC.ApellidoM;
            _contextoCAEF.Add(usuario);
        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return _contextoCAEF.Usuarios
                .Include(u => u.Rol)
                .ToList();
        }

        public async Task<bool> GuardarCambios()
        {
            return (await _contextoCAEF.SaveChangesAsync()) > 0;
        }

        public bool UsuarioExiste(Usuario usuario)
        {
            var resultado = _contextoUABC.UsuariosUABC
                .Where(u => u.Matricula == usuario.Id)
                .FirstOrDefault();

            return resultado == null ? false: true;
        }

        public IEnumerable<Rol> ObtenerRoles()
        {
            return _contextoCAEF.Roles.ToList();
        }

        public bool UsuarioDuplicado(Usuario usuario)
        {
            var resultado = _contextoCAEF.Usuarios
                .Where(u => u.Id == usuario.Id)
                .FirstOrDefault();

            return resultado == null ? false : true;
        }

        public void EditarUsuario(Usuario usuario)
        {
            var resultado = _contextoCAEF.Usuarios
                .Where(u => u.Id == usuario.Id)
                .FirstOrDefault();

            if(resultado != null)
            {
                resultado.RolId = usuario.RolId;
                _contextoCAEF.Usuarios.Update(resultado);
            }
        }

        public void BorrarUsuario(Usuario usuario)
        {
            var resultado = _contextoCAEF.Usuarios
                .Where(u => u.Id == usuario.Id)
                .FirstOrDefault();

            if(resultado != null) _contextoCAEF.Usuarios.Remove(resultado);
        }
    }
}
