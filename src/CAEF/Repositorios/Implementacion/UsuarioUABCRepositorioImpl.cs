using CAEF.Models.Contexts;
using CAEF.Models.Entities.UABC;
using System.Collections.Generic;
using System.Linq;
using System;
using CAEF.Repositorios;

namespace CAEF.Models.Repositories
{
    public class UsuarioUABCRepositorioImpl : IUsuarioUABCRepository
    {
        private UsuarioUABCContext _context;

        public UsuarioUABCRepositorioImpl(UsuarioUABCContext context)
        {
            _context = context;
        }

        public List<UsuarioUABC> ObtenerUsuarios()
        {
            return _context.UsuariosUABC.ToList();
        }

        public UsuarioUABC BuscarPorCorreo(string correo)
        {
            UsuarioUABC usuarioUABC;
            try
            {
                usuarioUABC = _context.UsuariosUABC
                 .Where(u => u.Email == correo)
                 .FirstOrDefault<UsuarioUABC>();
            }
            catch (Exception ex)
            {
                return null;
            }

            return usuarioUABC;
        }
    }
}
