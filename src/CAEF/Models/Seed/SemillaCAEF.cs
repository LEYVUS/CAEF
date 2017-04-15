using CAEF.Models.Contexts;
using CAEF.Models.Entities.CAEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Models.Seed
{
    public class SemillaCAEF
    {
        private CAEFContext _context;

        public SemillaCAEF(CAEFContext context)
        {
            _context = context;
        }

        /*
         * Genera datos automáticamente dentro de la base de
         * datos (UsuariosUABC) en caso de encontrarse vacía
         */
        public async Task GeneraDatosSemilla()
        {
            // Checa si las tablas de la base de dato se encuentran vacía
            if (!_context.Roles.Any())
            {
                var rolAmin = new Rol()
                {
                     Nombre = "Administrador"
                };

                var rolUsuario = new Rol()
                {
                    Nombre = "Usuario"
                };

                _context.Roles.Add(rolAmin);
                _context.Roles.Add(rolUsuario);
                await _context.SaveChangesAsync();
            }

            if (!_context.Usuarios.Any())
            {
                var usuarioA = new Usuario()
                {
                    Id = 338323,
                    Nombre = "José Ramón",
                    ApellidoP = "López",
                    ApellidoM = "Madueño",
                    Correo = "rlopez1@uabc.edu.mx",
                    RolId = 1
                };

                var usuarioB = new Usuario()
                {
                    Id = 335127,
                    Nombre = "César Samuel",
                    ApellidoP = "Parra",
                    ApellidoM = "Salas",
                    Correo = "samuel.parra@uabc.edu.mx",
                    RolId = 1
                };

                var usuarioC = new Usuario()
                {
                    Id = 331364,
                    Nombre = "Celso",
                    ApellidoP = "Figueroa",
                    ApellidoM = "Jacinto",
                    Correo = "celso.figueroa@uabc.edu.mx",
                    RolId = 1
                };

                _context.Usuarios.Add(usuarioA);
                _context.Usuarios.Add(usuarioB);
                _context.Usuarios.Add(usuarioC);
                await _context.SaveChangesAsync();
            }
        }
    }
}
