using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Prodi.Core.Web.DataAccess.Models
{
    public partial class DbContextLocal : DbContext
    {
        public DbContextLocal()
        {
        }

        public DbContextLocal(DbContextOptions<DbContextLocal> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Clasificacion> Clasificacion { get; set; }
        public virtual DbSet<Clasificador> Clasificador { get; set; }
        public virtual DbSet<Deporte> Deporte { get; set; }
        public virtual DbSet<Deportista> Deportista { get; set; }
        public virtual DbSet<EstudiosMedicos> EstudiosMedicos { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Nacionalidad> Nacionalidad { get; set; }
        public virtual DbSet<Participa> Participa { get; set; }
        public virtual DbSet<Predio> Predio { get; set; }
        public virtual DbSet<Provincia> Provincia { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TipoClasificacion> TipoClasificacion { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-U5SJSE4;DataBase=ProDi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(20);
            });

            modelBuilder.Entity<Clasificacion>(entity =>
            {
                entity.Property(e => e.Clasificacion1).HasColumnName("Clasificacion");

                entity.Property(e => e.FechaAlta).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdClasificadorNavigation)
                    .WithMany(p => p.Clasificacion)
                    .HasForeignKey(d => d.IdClasificador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clasificacion_IdClasificador");

                entity.HasOne(d => d.IdDeportistaNavigation)
                    .WithMany(p => p.Clasificacion)
                    .HasForeignKey(d => d.IdDeportista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clasificacion_IdDeportista");

                entity.HasOne(d => d.IdEstudiosMedicosNavigation)
                    .WithMany(p => p.Clasificacion)
                    .HasForeignKey(d => d.IdEstudiosMedicos)
                    .HasConstraintName("fk_clasificacion_IdEstudiosmedicos");

                entity.HasOne(d => d.IdTipoClasificacionNavigation)
                    .WithMany(p => p.Clasificacion)
                    .HasForeignKey(d => d.IdTipoClasificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clasificacion_IdTipoClasificacion");
            });

            modelBuilder.Entity<Clasificador>(entity =>
            {
                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdTipoClasificacionNavigation)
                    .WithMany(p => p.Clasificador)
                    .HasForeignKey(d => d.IdTipoClasificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cla_IdTipoClasificacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Clasificador)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cla_IdUsuario");
            });

            modelBuilder.Entity<Deporte>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prueba)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoClasificacionNavigation)
                    .WithMany(p => p.Deporte)
                    .HasForeignKey(d => d.IdTipoClasificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_deporte_IdTipoClasificacion");
            });

            modelBuilder.Entity<Deportista>(entity =>
            {
                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Deportista)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_deportista_IdCategoria");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Deportista)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_deportista_IdUsuario");
            });

            modelBuilder.Entity<EstudiosMedicos>(entity =>
            {
                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ruta).IsRequired();
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.Property(e => e.Marca1).HasColumnName("Marca");

                entity.Property(e => e.TipoMarca)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.Marca)
                    .HasForeignKey(d => d.IdDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_marca_IdDeporte");

                entity.HasOne(d => d.IdDeportistaNavigation)
                    .WithMany(p => p.Marca)
                    .HasForeignKey(d => d.IdDeportista)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_marca_IdDeportista");

                entity.HasOne(d => d.IdTorneoNavigation)
                    .WithMany(p => p.Marca)
                    .HasForeignKey(d => d.IdTorneo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_marca_IdTorneo");
            });

            modelBuilder.Entity<Nacionalidad>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Participa>(entity =>
            {
                entity.HasOne(d => d.IdTorneoNavigation)
                    .WithMany(p => p.Participa)
                    .HasForeignKey(d => d.IdTorneo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_participa_IdTorne");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Participa)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_participa_IdUsuario");
            });

            modelBuilder.Entity<Predio>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.Latitud).HasMaxLength(40);

                entity.Property(e => e.Longitud).HasMaxLength(40);

                entity.Property(e => e.Telefono).HasMaxLength(40);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Predio)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("fk_predio_IdProvincia");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoClasificacion>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(10);
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Torneo>(entity =>
            {
                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_torneo_IdCategoria");

                entity.HasOne(d => d.IdDeporteNavigation)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.IdDeporte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_torneo_IdDeporte");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_torneo_IdGenero");

                entity.HasOne(d => d.IdOrganizadorNavigation)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.IdOrganizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_torneo_IdOrganizador");

                entity.HasOne(d => d.IdPredioNavigation)
                    .WithMany(p => p.Torneo)
                    .HasForeignKey(d => d.IdPredio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_torneo_IdPredio");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion).IsRequired();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDoc)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.NumeroTelefonico).HasColumnName("numeroTelefonico");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_IdGenero");

                entity.HasOne(d => d.IdNacionalidadNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdNacionalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_IdNacionalidad");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_IdProvincia");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_IdRol");

                entity.HasOne(d => d.IdTipoDocNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoDoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user_IdTipoDoc");
            });
        }
    }
}
