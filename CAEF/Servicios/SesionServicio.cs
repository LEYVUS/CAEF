

using CAEF.Models.Entidades;
using CAEF.Models.Entidades.DTO;
using CAEF.Repositorios.Implementacion;
using CAEF.Servicios.Componente;


namespace CAEF.Servicios
{
    /// <summary>
    /// 
    /// </summary>
    public class SesionServicio
    {
        private UsuarioUABCRepositorioImpl usuarioRepositorioUABC;
        private UsuarioFIADRepositorioImpl usuarioRepositorioFiad;
        private UsuarioRepositorioImpl usuarioRepositorioSS;

        /// <summary>
        /// 
        /// </summary>
        public SesionServicio()
        {
            usuarioRepositorioUABC = new UsuarioUABCRepositorioImpl();

            usuarioRepositorioSS = new UsuarioRepositorioImpl(new EntidadesCAEF());
        }

        /// <summary>
        /// Verifica el inicio de sesion
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Devuelve un mensaje dependiendo del tipo de inicio de sesion</returns>
        public MensajeDTO InicioSesion(UsuarioDTO usuario)
        {
            Models.Entidades.UABC.Usuario usuarioUABC = usuarioRepositorioUABC.BuscarPorCorreo(usuario.Correo);

            if (usuarioUABC != null)
            {
                if (usuario.Contrasenia.Equals(usuarioUABC.Contraseña))
                {
                    Models.Entidades.FIAD.Usuario usuarioFIAD = usuarioRepositorioFiad.BuscarPorCorreo(usuario.Correo);

                    if (usuarioFIAD != null)
                    {
                        Models.Entidades.Usuario usuarioSS = usuarioRepositorioSS.BuscarPorCorreo(usuario.Correo);

                        if (usuarioSS != null)
                        {
                            UsuarioDTO usuarioAdministrativo = TransferirDTO.TransferirUsuario(usuarioSS);
                            usuarioAdministrativo.Nombre = usuarioUABC.Nombre;
                            usuarioAdministrativo.Apellido = usuarioUABC.Apellido;
                            usuarioAdministrativo.Numero_Empleado = usuarioUABC.Numero_Empleado;
                            return MensajeComponente.mensaje("Se ha iniciado sesion como " + usuarioAdministrativo.Rol.Nombre, usuarioAdministrativo);
                        }
                        else
                        {
                            UsuarioDTO usuarioProfesor = new UsuarioDTO();
                            usuarioProfesor.Nombre = usuarioUABC.Nombre;
                            usuarioProfesor.Apellido = usuarioUABC.Apellido;
                            return MensajeComponente.mensaje("Se ha iniciado sesion como Profesor", usuarioProfesor);
                        }
                    }
                    else
                    {
                        return MensajeComponente.mensaje("El usuario no pertenece a la Facultad de Ingenieria, Arquitectura y Diseño", null);

                    }
                }
                else
                {
                    return MensajeComponente.mensaje("La contraseña introducida es incorrecta", null);

                }
            }
            else
            {
                return MensajeComponente.mensaje("El usuario no pertenece a el dominio de UABC", null);

            }


        }

    }
}