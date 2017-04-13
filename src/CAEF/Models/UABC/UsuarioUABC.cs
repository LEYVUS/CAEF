using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Models.UABC
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
