namespace CAEF.Models.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SolicitudAdministrativo")]
    public partial class SolicitudAdministrativo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdSolicitud { get; set; }

        [Required]
        public string CalificacionLetra { get; set; }

        [Required]
        public string CicloEscolar { get; set; }

        [Required]
        public string ClaveUnidad { get; set; }

        [Required]
        public string Comentario { get; set; }

        [Required]
        public string EtapaSemestre { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaAceptacion { get; set; }

        public int IdSubtipoExamen { get; set; }

        public int NumeroAlumnos { get; set; }

        [Required]
        public string PlanEstudios { get; set; }

        public int? SubTipoExamenId { get; set; }

        [Required]
        public string URLDocumento { get; set; }

        [Required]
        public string UnidadAcademica { get; set; }

        public virtual SolicitudDocente SolicitudDocente { get; set; }

        public virtual SubtipoExaman SubtipoExaman { get; set; }
    }
}
