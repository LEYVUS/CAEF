using CAEF.Models.Contexts;
using CAEF.Models.Entities.CAEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Repositories
{
    public class UsuarioRepository : CRUDRepository<Usuario>, IUsuarioRepository
    {        
        //private UsuarioUABCContext _contextoUABC;
        public UsuarioRepository(CAEFContext contectoCAEF, UsuarioUABCContext contextoUABC): base(contectoCAEF, contextoUABC)
        {

        }

        public bool ConsultarBaseDeDatosUABC(string correo)
        {
            throw new NotImplementedException();
        }

        public bool ConsultarBaseDeDatosFIAD(string correo)
        {
            throw new NotImplementedException();
        }
    }
}
