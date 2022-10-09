using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RinkuWeb.Models
{
    public partial class RinkuContext : DbContext
    {
        public RinkuContext()
        {
        }

        public RinkuContext(DbContextOptions<RinkuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Nomina> Nominas { get; set; }
        public virtual DbSet<Periodo> Periodos { get; set; }
        public virtual DbSet<TipoEmpleado> TipoEmpleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=74.208.42.188;database=Rinku; user=sa; pwd=R3v35a20.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.CvEmpleado);

                entity.Property(e => e.CvEmpleado).HasColumnName("Cv_Empleado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroEmpleado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Empleado");
            });

            modelBuilder.Entity<Movimiento>(entity =>
            {
                entity.HasKey(e => e.CvMovimiento);

                entity.Property(e => e.CvMovimiento).HasColumnName("Cv_Movimiento");

                entity.Property(e => e.CvEmpleado).HasColumnName("Cv_Empleado");

                entity.Property(e => e.CvTipoEmpleado).HasColumnName("Cv_Tipo_Empleado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.HDesc).HasColumnName("HDesc");

                entity.Property(e => e.NumEntregas).HasColumnName("Num_Entregas");

                entity.HasOne(d => d.CvEmpleadoNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.CvEmpleado)
                    .HasConstraintName("FK_Movimientos_Empleados");

                entity.HasOne(d => d.CvTipoEmpleadoNavigation)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.CvTipoEmpleado)
                    .HasConstraintName("FK_Movimientos_Tipo_Empleado");
            });

            modelBuilder.Entity<Nomina>(entity =>
            {
                entity.HasKey(e => e.CvNomina);

                entity.Property(e => e.CvNomina).HasColumnName("Cv_Nomina");

                entity.Property(e => e.BonoEntregas).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BonoPuesto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CvMovimiento).HasColumnName("Cv_Movimiento");

                entity.Property(e => e.CvPeriodo).HasColumnName("Cv_Periodo");

                entity.Property(e => e.Retenciones).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SueldoBruto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SueldoNeto).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValesDespensa)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Vales_Despensa");

                entity.HasOne(d => d.CvMovimientoNavigation)
                    .WithMany(p => p.Nominas)
                    .HasForeignKey(d => d.CvMovimiento)
                    .HasConstraintName("FK_Nominas_Movimientos");

                entity.HasOne(d => d.CvPeriodoNavigation)
                    .WithMany(p => p.Nominas)
                    .HasForeignKey(d => d.CvPeriodo)
                    .HasConstraintName("FK_Nominas_Periodos");
            });

            modelBuilder.Entity<Periodo>(entity =>
            {
                entity.HasKey(e => e.CvPeriodo);

                entity.Property(e => e.CvPeriodo).HasColumnName("Cv_Periodo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MesPeriodo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mes_Periodo");

                entity.Property(e => e.NumMesPeriodo).HasColumnName("Num_Mes_Periodo");
            });

            modelBuilder.Entity<TipoEmpleado>(entity =>
            {
                entity.HasKey(e => e.CvTipoEmpleado);

                entity.ToTable("Tipo_Empleado");

                entity.Property(e => e.CvTipoEmpleado).HasColumnName("Cv_Tipo_Empleado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.NombreTipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Tipo");

                entity.Property(e => e.TabuladorHora)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Tabulador_Hora");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
