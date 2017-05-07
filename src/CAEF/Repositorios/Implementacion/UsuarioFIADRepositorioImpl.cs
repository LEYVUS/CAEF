using CAEF.Models.Contexts;
using CAEF.Models.Entities.FIAD;
using CAEF.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Models.Repositories
{
    public class UsuarioFIADRepositorioImpl : IUsuarioFIADRepositorio
    {
        private UsuarioFIADContext _context;

        public UsuarioFIADRepositorioImpl(UsuarioFIADContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioFIAD> ObtenerUsuarios()
        {
            return _context.UsuariosFIAD.ToList();
        }

        public UsuarioFIAD BuscarPorCorreo(string correo)
        {
            UsuarioFIAD usuarioFIAD;
            try
            {
                usuarioFIAD = _context.UsuariosFIAD
                 .Where(u => u.Correo == correo)
                 .FirstOrDefault<UsuarioFIAD>();
            }
            catch (Exception ex)
            {
                return null;
            }

            return usuarioFIAD;
        }
    }
}
