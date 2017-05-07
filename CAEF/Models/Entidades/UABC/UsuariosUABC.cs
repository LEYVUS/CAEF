namespace CAEF.Models.Entidades.UABC
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UsuariosUABC : DbContext
    {
        public UsuariosUABC()
            : base("name=UsuariosUABC")
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);
        }
    }
}
