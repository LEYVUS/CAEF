namespace CAEF.Models.Entidades.FIAD
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UsuariosFIAD : DbContext
    {
        public UsuariosFIAD()
            : base("name=UsuariosFIAD")
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
