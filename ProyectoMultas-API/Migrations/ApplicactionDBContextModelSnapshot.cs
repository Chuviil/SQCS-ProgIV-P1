﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoMultas_API.Data;

#nullable disable

namespace ProyectoMultas_API.Migrations
{
    [DbContext(typeof(ApplicactionDBContext))]
    partial class ApplicactionDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoMultas_API.Models.Ayudante", b =>
                {
                    b.Property<string>("IdBanner")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Carrera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBanner");

                    b.ToTable("Ayudantes");
                });

            modelBuilder.Entity("ProyectoMultas_API.Models.Multa", b =>
                {
                    b.Property<int>("MultaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MultaId"));

                    b.Property<string>("AyudanteId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Monto")
                        .HasColumnType("float");

                    b.Property<string>("Razon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MultaId");

                    b.HasIndex("AyudanteId");

                    b.ToTable("Multas");
                });

            modelBuilder.Entity("ProyectoMultas_API.Models.Profesor", b =>
                {
                    b.Property<string>("IdBanner")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBanner");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("ProyectoMultas_API.Models.Multa", b =>
                {
                    b.HasOne("ProyectoMultas_API.Models.Ayudante", "Ayudante")
                        .WithMany("Multas")
                        .HasForeignKey("AyudanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ayudante");
                });

            modelBuilder.Entity("ProyectoMultas_API.Models.Ayudante", b =>
                {
                    b.Navigation("Multas");
                });
#pragma warning restore 612, 618
        }
    }
}
