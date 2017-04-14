using System.ComponentModel.DataAnnotations;

namespace CAEF.Models.Entities.CAEF
{
    public class Materia
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
