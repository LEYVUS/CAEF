using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAEF.Models.Entities.CAEF
{
    public class Solicitud
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Materia")]
        public int Id_Materia { get; set; }
        public string Periodo { get; set; }
        [ForeignKey("Carrera")]
        public int Id_Carrera { get; set; }
        [ForeignKey("TipoExamen")]
        public int Id_TipoExamen { get; set; }
        [ForeignKey("Usuario")]
        public int Id_Empleado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Motivo { get; set; }
        [ForeignKey("Estado")]
        public int Id_Estado { get; set; }
        public virtual Materia Materia { get; set; }
        public virtual Carrera Carrera { get; set; }
        public virtual TipoExamen TipoExamen { get; set; }
        public virtual Usuario Empleado { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
