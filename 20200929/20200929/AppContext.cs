using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _20200929
{
    public class AppContext : DbContext
    {
        public DbSet<Actividad> Actividades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // COMPLETAR!
        }

    }
}
