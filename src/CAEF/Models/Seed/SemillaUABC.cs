using CAEF.Models.Contexts;
using CAEF.Models.Entities.UABC;
using System.Linq;
using System.Threading.Tasks;

namespace CAEF.Models.Seed
{
    public class SemillaUABC
    {
        private UsuarioUABCContext _context;

        public SemillaUABC(UsuarioUABCContext context)
        {
            _context = context;
        }

        /*
         * Genera datos automáticamente dentro de la base de
         * datos (UsuariosUABC) en caso de encontrarse vacía
         */
        public async Task GeneraDatosSemilla()
        {
            // Checa si la base de datos se encuentra vacía
            if (!_context.UsuariosUABC.Any())
            {
                var usuarioA = new UsuarioUABC()
                {
                    Nombre = "José Ramón",
                    ApellidoP = "López",
                    ApellidoM = "Madueño",
                    Correo = "rlopez1@uabc.edu.mx",
                    Password = "password"
                };

                var usuarioB = new UsuarioUABC()
                {
                    Nombre = "César Samuel",
                    ApellidoP = "Parra",
                    ApellidoM = "Salas",
                    Correo = "samuel.parra@uabc.edu.mx",
                    Password = "password"
                };

                var usuarioC = new UsuarioUABC()
                {
                    Nombre = "Celso",
                    ApellidoP = "Figueroa",
                    ApellidoM = "Jacinto",
                    Correo = "celso.figueroa@uabc.edu.mx",
                    Password = "password"
                };

                _context.UsuariosUABC.Add(usuarioA);
                _context.UsuariosUABC.Add(usuarioB);
                _context.UsuariosUABC.Add(usuarioC);

                await _context.SaveChangesAsync();
            }
        }
    }
}
