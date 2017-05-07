namespace CAEF.Models.Entidades
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntidadesCAEF : DbContext
    {
        public EntidadesCAEF()
            : base("name=EntidadesCAEF")
        {
        }

        public virtual DbSet<Alumno> Alumnoes { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<Materia> Materias { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<SolicitudAdministrativo> SolicitudAdministrativoes { get; set; }
        public virtual DbSet<SolicitudAlumno> SolicitudAlumnoes { get; set; }
        public virtual DbSet<SolicitudDocente> SolicitudDocentes { get; set; }
        public virtual DbSet<SubtipoExaman> SubtipoExamen { get; set; }
        public virtual DbSet<TipoExaman> TipoExamen { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.SolicitudAlumnoes)
                .WithRequired(e => e.Alumno)
                .HasForeignKey(e => e.IdAlumno);

            modelBuilder.Entity<Carrera>()
                .HasMany(e => e.SolicitudDocentes)
                .WithRequired(e => e.Carrera)
                .HasForeignKey(e => e.IdCarrera);

            modelBuilder.Entity<Estado>()
                .HasMany(e => e.SolicitudDocentes)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.IdEstado);

            modelBuilder.Entity<Materia>()
                .HasMany(e => e.SolicitudDocentes)
                .WithRequired(e => e.Materia)
                .HasForeignKey(e => e.IdMateria);

            modelBuilder.Entity<SolicitudDocente>()
                .HasOptional(e => e.SolicitudAdministrativo)
                .WithRequired(e => e.SolicitudDocente)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SolicitudDocente>()
                .HasMany(e => e.SolicitudAlumnoes)
                .WithRequired(e => e.SolicitudDocente)
                .HasForeignKey(e => e.IdSolicitud);

            modelBuilder.Entity<SubtipoExaman>()
                .HasMany(e => e.SolicitudAdministrativoes)
                .WithOptional(e => e.SubtipoExaman)
                .HasForeignKey(e => e.SubTipoExamenId);

            modelBuilder.Entity<TipoExaman>()
                .HasMany(e => e.SolicitudDocentes)
                .WithRequired(e => e.TipoExaman)
                .HasForeignKey(e => e.IdTipoExamen);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.SolicitudDocentes)
                .WithOptional(e => e.Usuario)
                .HasForeignKey(e => e.EmpleadoId);
        }
    }
}
