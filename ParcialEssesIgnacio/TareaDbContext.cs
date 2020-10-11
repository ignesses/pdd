using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcialEssesIgnacio
{
    public class TareaDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tarea.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario")
                .Property(p => p.Clave);
            modelBuilder.Entity<Tarea>()
                .ToTable("Tarea");
            modelBuilder.Entity<Recurso>()
                .ToTable("Recurso");
            modelBuilder.Entity<Detalle>()
                .ToTable("Detalle");
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarea> Tarea { get; set; }

    }
}
