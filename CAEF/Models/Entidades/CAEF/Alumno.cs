namespace CAEF.Models.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alumno")]
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            SolicitudAlumnoes = new HashSet<SolicitudAlumno>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Matricula_Alumno { get; set; }

        [Required]
        public string ApellidoM { get; set; }

        [Required]
        public string ApellidoP { get; set; }

        public int Grupo { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int Promedio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudAlumno> SolicitudAlumnoes { get; set; }
    }
}
