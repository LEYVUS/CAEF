using CAEF.Models.Contexts;
using CAEF.Models.Entities.CAEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAEF.Services;

namespace CAEF.Repositories
{
    public class CAEFRepository : ICAEFRepository
    {
        private CAEFContext _contextoCAEF;
        private UsuarioUABCContext _contextoUABC;
        private RolServices _servicioRol;

        public CAEFRepository(CAEFContext contextoCAEF, UsuarioUABCContext contextoUABC, RolServices servicioRol)
        {
            _contextoCAEF = contextoCAEF;
            _contextoUABC = contextoUABC;
            _servicioRol = servicioRol;
        }

        public IEnumerable<Materia> ObtenerMaterias()
        {
            return _contextoCAEF.Materias.ToList();
        }
    }
}
