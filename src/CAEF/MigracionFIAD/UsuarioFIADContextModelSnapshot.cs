using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CAEF.Models.Contexts;

namespace CAEF.MigracionFIAD
{
    [DbContext(typeof(UsuarioFIADContext))]
    partial class UsuarioFIADContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CAEF.Models.FIAD.UsuarioFIAD", b =>
                {
                    b.Property<int>("Numero_Empleado")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApellidoM");

                    b.Property<string>("ApellidoP");

                    b.Property<string>("Correo");

                    b.Property<string>("Nombre");

                    b.HasKey("Numero_Empleado");

                    b.ToTable("UsuariosFIAD");
                });
        }
    }
}
