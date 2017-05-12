using CAEF.Models.Contexts;
using CAEF.Models.Entities.CAEF;
using System.Collections.Generic;
using System.Linq;

namespace CAEF.Services
{
    public class RolServices
    {
        private CAEFContext _contextoCAEF;
        private UsuarioUABCContext _contextoUABC;

        public RolServices(CAEFContext contextoCAEF, UsuarioUABCContext contextoUABC)
        {
            _contextoCAEF = contextoCAEF;
            _contextoUABC = contextoUABC;
        }

        public IEnumerable<Rol> ObtenerRoles()
        {
            return _contextoCAEF.Roles.ToList();
        }
    }
}
