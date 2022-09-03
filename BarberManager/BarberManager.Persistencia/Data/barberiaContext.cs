using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BarberManager.Persistencia.Data
{
    public partial class barberiaContext : DbContext
    {
        public barberiaContext()
        {
        }

        public barberiaContext(DbContextOptions<barberiaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barbero> Barberos { get; set; }
        public virtual DbSet<DetalleProducto> DetalleProductos { get; set; }
        public virtual DbSet<DetalleServicio> DetalleServicios { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Servicio> Servicios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=20.168.13.51; Database=barberia; user=sa; password=P3g4sus.2022*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barbero>(entity =>
            {
                entity.ToTable("barberos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documento");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_documento");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Barberos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_barberos_usuarios");
            });

            modelBuilder.Entity<DetalleProducto>(entity =>
            {
                entity.ToTable("detalle_productos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdProductos).HasColumnName("id_productos");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdProductosNavigation)
                    .WithMany(p => p.DetalleProductos)
                    .HasForeignKey(d => d.IdProductos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_productos_productos");
            });

            modelBuilder.Entity<DetalleServicio>(entity =>
            {
                entity.ToTable("detalle_servicios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdServicios).HasColumnName("id_servicios");

                entity.Property(e => e.IdVentas).HasColumnName("id_ventas");

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.HasOne(d => d.IdServiciosNavigation)
                    .WithMany(p => p.DetalleServicios)
                    .HasForeignKey(d => d.IdServicios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_servicios_servicios");

                entity.HasOne(d => d.IdVentasNavigation)
                    .WithMany(p => p.DetalleServicios)
                    .HasForeignKey(d => d.IdVentas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_detalle_servicios_ventas");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("productos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Disponible).HasColumnName("disponible");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("servicios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio).HasColumnName("precio");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarios_tipos");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("ventas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdBarberos).HasColumnName("id_barberos");

                entity.Property(e => e.IdUsuarios).HasColumnName("id_usuarios");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdBarberosNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdBarberos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_barberos");

                entity.HasOne(d => d.IdUsuariosNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdUsuarios)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
