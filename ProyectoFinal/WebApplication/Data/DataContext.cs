using Microsoft.EntityFrameworkCore;
using ClassLibrary;

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
        }

        public DbSet<TipoTarea> TipoTareas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Detalle> Detalles { get; set; }

    }
}
