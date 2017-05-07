

namespace CAEF.Models.Entidades.DTO
{
    public class UsuarioDTO
    {
        public UsuarioDTO()
        {
        }

        /// <summary>
        /// Constructor de Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="correo"></param>
        /// <param name="rol"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="numero_Empleado"></param>
        public UsuarioDTO(int id, string correo, RolDTO rol, string nombre, string apellido, int numero_Empleado)
        {
            Id = id;
            Correo = correo;
            Rol = rol;
            Nombre = nombre;
            Apellido = apellido;
            Numero_Empleado = numero_Empleado;
        }

        /// <summary>
        /// Constructor de Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="correo"></param>
        /// <param name="rol"></param>
        public UsuarioDTO(int id, string correo, RolDTO rol)
        {
            Id = id;
            Correo = correo;
            Rol = rol;
        }

        public int Id { get; set; }

        public string Correo { get; set; }

        public RolDTO Rol { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Contrasenia { get; set; }

        public int Numero_Empleado { get; set; }

    }
}
