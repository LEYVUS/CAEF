namespace CAEF.Models.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SolicitudAlumno")]
    public partial class SolicitudAlumno
    {
        public int Id { get; set; }

        public int IdAlumno { get; set; }

        public int IdSolicitud { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual SolicitudDocente SolicitudDocente { get; set; }
    }
}
