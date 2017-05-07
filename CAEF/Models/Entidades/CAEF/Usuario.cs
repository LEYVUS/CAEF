namespace CAEF.Models.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            SolicitudDocentes = new HashSet<SolicitudDocente>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Numero_Empleado { get; set; }

        public string ApellidoM { get; set; }

        public string ApellidoP { get; set; }

        [Required]
        public string Correo { get; set; }

        public string Nombre { get; set; }

        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudDocente> SolicitudDocentes { get; set; }
    }
}
