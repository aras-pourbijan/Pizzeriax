using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Pizzeriax.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelDBcontext")
        {
        }

        public virtual DbSet<Detagli> Detagli { get; set; }
        public virtual DbSet<Ordini> Ordini { get; set; }
        public virtual DbSet<Pizze> Pizze { get; set; }
        public virtual DbSet<users> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ordini>()
                .HasMany(e => e.Detagli)
                .WithRequired(e => e.Ordini)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pizze>()
                .Property(e => e.prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pizze>()
                .HasMany(e => e.Detagli)
                .WithRequired(e => e.Pizze)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users>()
                .Property(e => e.tel)
                .IsUnicode(false);

            modelBuilder.Entity<users>()
                .HasMany(e => e.Ordini)
                .WithRequired(e => e.users)
                .WillCascadeOnDelete(false);
        }
    }
}
