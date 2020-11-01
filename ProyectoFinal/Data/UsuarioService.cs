using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _ProyectoFinal.Data
{
    public class UsuarioService
    {
        /*
        public Usuario[] GetUsuarios()
        {
            Usuario[] resultado = new Usuario[5];
            resultado[0] = new Usuario(1, "User1", 1234);
            resultado[1] = new Usuario(1, "User1", 1234);
            resultado[2] = new Usuario(1, "User1", 1234);
            resultado[3] = new Usuario(1, "User1", 1234);
            resultado[4] = new Usuario(1, "User1", 1234);

            return resultado;
        }
        */

        private TaskDbContext context;

        public UsuarioService(TaskDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Get(int id)
        {
            return await context.Usuarios.Where(i => i.Id_User == id).SingleAsync();
        }

        public async Task<Usuario> Save(Usuario value)
        {
            if (value.Id_User == 0)
            {
                await context.Usuarios.AddAsync(value);
            }
            else
            {
                context.Usuarios.Update(value);
            }
            await context.SaveChangesAsync();
            return value;
        }

        public async Task<bool> Remove(int id)
        {
            var entidad = await context.Usuarios.Where(i => i.Id_User == id).SingleAsync();
            context.Usuarios.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }


        public void ConsultarUsuarios()
        {
            var ctx = new TaskDbContext();
            var lista = ctx.Usuarios.ToList();
            Console.WriteLine("\n-----> Usuarios en DB:\n");
            foreach (var item in lista)
            {
                Console.WriteLine($"ID {item.Id_User}: {item.User} ({item.Clave})");
            }
        }

        public void InsertarUsuario()
        {
            var ctx = new TaskDbContext();

            Console.WriteLine("Ingrese el nombre de usuario: ");
            string usuario = Console.ReadLine();
            Console.WriteLine("Ingrese la clave numérica: ");
            int clave = int.Parse(Console.ReadLine());

            ctx.Set<Usuario>().Add(new Usuario
            {
                User = usuario,
                Clave = clave,
            });

            ctx.SaveChanges();
            Console.WriteLine("\n*************** GUARDADO ***************\n");
        }

        public void EliminarUsuario()
        {
            Console.WriteLine("\n¿Desea eliminar ingresando el nombre de usuario? Y/N");
            string accion = Console.ReadLine();
            if (accion == "Y")
            {
                Console.WriteLine("\nIngrese el nombre del usuario que desea borrar: ");
                string usuario = Console.ReadLine();

                var ctx = new TaskDbContext();
                var user = ctx.Usuarios.Where(i => i.User == usuario).Single();
                ctx.Usuarios.Remove(user);
                ctx.SaveChanges();
                Console.WriteLine("\n*************** ELIMINADO ***************\n");
            }
            else if (accion == "N")
            {
                Console.WriteLine("\nIngrese el ID del usuario que desea borrar: ");
                int usuarioID = int.Parse(Console.ReadLine());

                var ctx = new TaskDbContext();
                var user = ctx.Usuarios.Where(i => i.Id_User == usuarioID).Single();
                ctx.Usuarios.Remove(user);
                ctx.SaveChanges();
                Console.WriteLine("\n*************** ELIMINADO ***************\n");
            }
            else
            {
                Console.WriteLine("\n*************** Ingrese una opción válida ***************\n");
            }
        }

        public void ModificarUsuario()
        {
            Console.WriteLine("\nIngrese el ID del usuario que desea modificar: ");
            int usuario = int.Parse(Console.ReadLine());
            var ctx = new TaskDbContext();
            /* Voy a recibir un único usuario porque paso como parámetro el ID,
             * dejo esta notación por si lo cambio más adelante.
             */
            var lista = ctx.Usuarios.Where(i => i.Id_User == usuario).ToList();

            Console.WriteLine("Ingrese el nuevo nombre de usuario: ");
            string usuarioNuevo = Console.ReadLine();
            Console.WriteLine("Ingrese la clave numérica: ");
            int claveNueva = int.Parse(Console.ReadLine());

            lista[0].User = usuarioNuevo;
            lista[0].Clave = claveNueva;

            ctx.SaveChanges();
            Console.WriteLine("\n*************** MODIFICADO ***************\n");
        }


    }
}
