using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<ARTICULOS> ARTICULOS { get; set; }
        public virtual DbSet<CATEGORIAS> CATEGORIAS { get; set; }
        public virtual DbSet<MARCAS> MARCAS { get; set; }
        public virtual DbSet<FAVORITOS> FAVORITOS { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ARTICULOS>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<ARTICULOS>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<ARTICULOS>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<ARTICULOS>()
                .Property(e => e.ImagenUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ARTICULOS>()
                .Property(e => e.Precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CATEGORIAS>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<MARCAS>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.urlImagenPerfil)
                .IsUnicode(false);
        }
    }
}
