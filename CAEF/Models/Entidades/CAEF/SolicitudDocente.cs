namespace CAEF.Models.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SolicitudDocente")]
    public partial class SolicitudDocente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SolicitudDocente()
        {
            SolicitudAlumnoes = new HashSet<SolicitudAlumno>();
        }

        public int Id { get; set; }

        public int? EmpleadoId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaCreacion { get; set; }

        public int IdCarrera { get; set; }

        public int IdEmpleado { get; set; }

        public int IdEstado { get; set; }

        public int IdMateria { get; set; }

        public int IdTipoExamen { get; set; }

        [Required]
        public string Motivo { get; set; }

        [Required]
        public string Periodo { get; set; }

        public virtual Carrera Carrera { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual Materia Materia { get; set; }

        public virtual SolicitudAdministrativo SolicitudAdministrativo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudAlumno> SolicitudAlumnoes { get; set; }

        public virtual TipoExaman TipoExaman { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
