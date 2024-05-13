using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace INSECAP.Models;

public partial class CapacitacionesContext : DbContext
{
    public CapacitacionesContext()
    {
    }

    public CapacitacionesContext(DbContextOptions<CapacitacionesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<AsignacionCursosAlu> AsignacionCursosAlus { get; set; }

    public virtual DbSet<AsignacionCursosPro> AsignacionCursosPros { get; set; }

    public virtual DbSet<Bimestre> Bimestres { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Nota> Notas { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            //=> optionsBuilder.UseSqlServer("server=localhost; database=Capacitaciones; integrated security=true; TrustServerCertificate=true;");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.RunAlumno);

            entity.ToTable("Alumno");

            entity.Property(e => e.RunAlumno)
                .ValueGeneratedNever()
                .HasColumnName("RUN_Alumno");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DvAlumno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DV_Alumno");
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AsignacionCursosAlu>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion);

            entity.ToTable("Asignacion_Cursos_Alu");

            entity.Property(e => e.IdAsignacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_Asignacion");
            entity.Property(e => e.CodigoCurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_Curso");
            entity.Property(e => e.CodigoSala)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_Sala");
            entity.Property(e => e.IdBimestre).HasColumnName("ID_Bimestre");
            entity.Property(e => e.RunAlumno).HasColumnName("RUN_Alumno");

            entity.HasOne(d => d.CodigoCursoNavigation).WithMany(p => p.AsignacionCursosAlus)
                .HasForeignKey(d => d.CodigoCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Cursos_Alu_Curso");

            entity.HasOne(d => d.CodigoSalaNavigation).WithMany(p => p.AsignacionCursosAlus)
                .HasForeignKey(d => d.CodigoSala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Cursos_Alu_Sala");

            entity.HasOne(d => d.IdBimestreNavigation).WithMany(p => p.AsignacionCursosAlus)
                .HasForeignKey(d => d.IdBimestre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Cursos_Alu_Bimestre");

            entity.HasOne(d => d.RunAlumnoNavigation)
                .WithMany(p => p.AsignacionCursosAlus)
                .HasForeignKey(d => d.RunAlumno)
                .OnDelete(DeleteBehavior.Cascade) // Cambia a DeleteBehavior.Cascade
                .HasConstraintName("FK_Asignacion_Cursos_Alu_Alumno");
        });

        modelBuilder.Entity<AsignacionCursosPro>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion);

            entity.ToTable("Asignacion_Cursos_Pro");

            entity.HasIndex(e => new { e.CodigoCurso, e.RunProfesor, e.IdBimestre }, "UQ_Asignacion_Cursos_Pro_Bimestre").IsUnique();

            entity.Property(e => e.IdAsignacion)
                .ValueGeneratedNever()
                .HasColumnName("ID_Asignacion");
            entity.Property(e => e.CodigoCurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_Curso");
            entity.Property(e => e.IdBimestre).HasColumnName("ID_Bimestre");
            entity.Property(e => e.RunProfesor).HasColumnName("RUN_Profesor");

            entity.HasOne(d => d.CodigoCursoNavigation).WithMany(p => p.AsignacionCursosPros)
                .HasForeignKey(d => d.CodigoCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Cursos_Pro_Curso");

            entity.HasOne(d => d.IdBimestreNavigation).WithMany(p => p.AsignacionCursosPros)
                .HasForeignKey(d => d.IdBimestre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Cursos_Pro_Bimestre");

            entity.HasOne(d => d.RunProfesorNavigation).WithMany(p => p.AsignacionCursosPros)
                .HasForeignKey(d => d.RunProfesor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Asignacion_Cursos_Pro_Profesor");
        });

        modelBuilder.Entity<Bimestre>(entity =>
        {
            entity.HasKey(e => e.IdBimestre);

            entity.ToTable("Bimestre");

            entity.Property(e => e.IdBimestre)
                .ValueGeneratedNever()
                .HasColumnName("ID_Bimestre");
            entity.Property(e => e.FechaFin).HasColumnName("Fecha_Fin");
            entity.Property(e => e.FechaInicio).HasColumnName("Fecha_Inicio");
            entity.Property(e => e.NumeroBimestre).HasColumnName("Numero_Bimestre");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CodigoCurso);

            entity.ToTable("Curso");

            entity.Property(e => e.CodigoCurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_Curso");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Curso");
        });

        modelBuilder.Entity<Nota>(entity =>
        {
            entity.HasKey(e => e.IdNota);

            entity.Property(e => e.IdNota)
                .ValueGeneratedNever()
                .HasColumnName("ID_Nota");
            entity.Property(e => e.CodigoCurso)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_Curso");
            entity.Property(e => e.IdBimestre).HasColumnName("ID_Bimestre");
            entity.Property(e => e.Nota1).HasColumnName("Nota");
            entity.Property(e => e.RunAlumno).HasColumnName("RUN_Alumno");

            entity.HasOne(d => d.CodigoCursoNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.CodigoCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notas_Curso");

            entity.HasOne(d => d.IdBimestreNavigation).WithMany(p => p.Nota)
                .HasForeignKey(d => d.IdBimestre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notas_Bimestre");

            entity.HasOne(d => d.RunAlumnoNavigation)
                .WithMany(p => p.Nota)
                .HasForeignKey(d => d.RunAlumno)
                .OnDelete(DeleteBehavior.Cascade) // Cambia a DeleteBehavior.Cascade
                .HasConstraintName("FK_Notas_Alumno");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.RunProfesor);

            entity.ToTable("Profesor");

            entity.Property(e => e.RunProfesor)
                .ValueGeneratedNever()
                .HasColumnName("RUN_Profesor");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DvProfesor)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DV_Profesor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.CodigoSala);

            entity.ToTable("Sala");

            entity.Property(e => e.CodigoSala)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Codigo_Sala");
            entity.Property(e => e.CapacidadMaxima).HasColumnName("Capacidad_Maxima");
            entity.Property(e => e.CaracteristicasEspeciales).HasColumnName("Caracteristicas_Especiales");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
