using System.ComponentModel.DataAnnotations;

namespace CAEF.Models.Entities.UABC
{
    public class UsuarioUABC
    {
        [Key]
        public int Numero_Empleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
