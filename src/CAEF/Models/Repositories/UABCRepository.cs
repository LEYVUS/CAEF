using CAEF.Models.Contexts;
using CAEF.Models.Entities.UABC;
using System.Collections.Generic;
using System.Linq;

namespace CAEF.Models.Repositories
{
    public class UABCRepository : IUABCRepository
    {
        private UsuarioUABCContext _context;

        public UABCRepository(UsuarioUABCContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioUABC> ObtenerUsuarios()
        {
            return _context.UsuariosUABC.ToList();
        }
    }
}
