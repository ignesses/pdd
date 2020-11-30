using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace WebApplication.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tareas.db");
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

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Detalle> Detalles { get; set; }

    }
}
