using System.ComponentModel.DataAnnotations;

namespace CAEF.Models.Entities.FIAD
{
    public class UsuarioFIAD
    {
        [Key]
        public int Numero_Empleado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
    }
}
