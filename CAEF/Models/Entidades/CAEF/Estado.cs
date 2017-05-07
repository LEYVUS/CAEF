namespace CAEF.Models.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estado")]
    public partial class Estado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estado()
        {
            SolicitudDocentes = new HashSet<SolicitudDocente>();
        }

        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime FechaModificacion { get; set; }

        [Required]
        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudDocente> SolicitudDocentes { get; set; }
    }
}
