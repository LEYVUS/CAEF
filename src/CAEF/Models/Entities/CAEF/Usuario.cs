using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAEF.Models.Entities.CAEF
{
    public class Usuario
    {
        [Required]
        [Column("Numero_Empleado")]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        [ForeignKey("Rol")]
        public int RolId { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
