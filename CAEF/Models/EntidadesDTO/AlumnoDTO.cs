using System.ComponentModel.DataAnnotations;

namespace CAEF.Models.Entidades.DTO
{
    public class AlumnoDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoP { get; set; }
        [Required]
        public string ApellidoM { get; set; }
        [Required]
        public int Grupo { get; set; }
        [Required]
        public int Promedio { get; set; }
    }
}
