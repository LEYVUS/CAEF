using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CAEF.Models.Contexts;

namespace CAEF.MigracionUABC
{
    [DbContext(typeof(UsuarioUABCContext))]
    [Migration("20170413024448_InicialUABC")]
    partial class InicialUABC
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CAEF.Models.UABC.UsuarioUABC", b =>
                {
                    b.Property<int>("Numero_Empleado")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApellidoM");

                    b.Property<string>("ApellidoP");

                    b.Property<string>("Correo");

                    b.Property<string>("Nombre");

                    b.Property<string>("Password");

                    b.HasKey("Numero_Empleado");

                    b.ToTable("UsuariosUABC");
                });
        }
    }
}
