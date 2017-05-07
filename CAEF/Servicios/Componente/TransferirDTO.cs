
using CAEF.Models.Entidades;
using CAEF.Models.Entidades.DTO;

namespace CAEF.Servicios.Componente
{
    /// <summary>
    /// 
    /// </summary>
    public static class TransferirDTO
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static UsuarioDTO TransferirUsuario(Usuario usuario)
        {

            RolDTO rolDTO = new RolDTO(usuario.Rol.Id,
                usuario.Rol.Nombre);
            UsuarioDTO usuarioDTO = new UsuarioDTO(usuario.Numero_Empleado,
                usuario.Correo, rolDTO);
            return usuarioDTO;
        }

        /// <summary>
        /// Transfiere las entidades de la solicitud a DTO
        /// </summary>
        /// <param name="solicitud"></param>
     
    }
}