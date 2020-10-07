using System;
using System.Linq;

namespace _20201006
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Insertar();
            Actualizacion2();
            Consultar();
        }

        static void Borrar()
        {
            var ctx = new TareasDbContext();
            var usuario = ctx.Usuarios.Where(i => i.Clave == 1).Single();
            ctx.Usuarios.Remove(usuario);
            ctx.SaveChanges();
        }

        static void Actualizacion()
        {
            var ctx = new TareasDbContext();
            var lista = ctx.Usuarios.Where(i => i.Clave == 1).ToList();
            lista[0].Nombre = "Facundo";
            ctx.SaveChanges();
        }

        static void Actualizacion2()
        {
            var ctx = new TareasDbContext();
            // Le dice al EntityFramework que devuelva un único registro:
            var usuario = ctx.Usuarios.Where(i => i.Clave == 1).Single();
            // Si no existe voy a tener un error.
            usuario.Nombre = "Facundo";

            var usuario2 = ctx.Usuarios.Where(i => i.Clave == 3).FirstOrDefault();
            if (usuario2 != null)
            {
                usuario2.Nombre = "Prueba";
            }

            var usuario3 = ctx.Usuarios.Where(i => i.Nombre == "Ignacio" && i.Clave<4).FirstOrDefault();
            if (usuario3 != null)
            {
                usuario3.Nombre = "Franco";
            }
            ctx.SaveChanges();
        }

        static void Consultar()
        {
            var ctx = new TareasDbContext();
            var lista = ctx.Usuarios.ToList();
            foreach (var item in lista)
            {
                Console.WriteLine($"Nombre: {item.Nombre} ({item.Codigo})");
            }

        }

        static void Insertar()
        {
            var ctx = new TareasDbContext();

            ctx.Set<Usuario>().Add(new Usuario
            {
                Codigo = 1,
                Nombre = "Ignacio",
                Clave = 1234
            });

            ctx.SaveChanges();

        }
    }
}
