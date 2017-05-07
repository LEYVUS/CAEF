

using CAEF.Models.Entidades;
using CAEF.Models.Entidades.DTO;

namespace CAEF.Servicios.Componente
{
    public static class TransferirEntidad
    {
        public static Usuario TransferirDatosUsuarioDTO(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario();
            usuario.Numero_Empleado = usuarioDTO.Id;
            usuario.Correo = usuarioDTO.Correo;
            usuario.RolId = usuarioDTO.Rol.Id;
            return usuario;

        }


        /// <summary>
        /// Transfiere todas los DTO a entidades
        /// </summary>
        /// <param name="solicitudDTO"></param>
        /// <returns>Deveulve las entidad solicitud</returns>
       
    }
}