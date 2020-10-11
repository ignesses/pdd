using System;
using System.Collections.Generic;
using System.Linq;

namespace ParcialEssesIgnacio
{
    /*
     * Notas:
     * Add-Migration " "
     * Update-Database
     */

    class Program
    {
        static void Main(string[] args)
        {
            int accion = 0;

            do
            {
                List<string> acciones = new List<string>
                {
                    "\n1# - Ver Usuarios",
                    "2# - Ver Tareas",
                    "3# - Insertar Usuario",
                    "4# - Insertar Tarea",
                    "5# - Modificar Usuario",
                    "6# - Modificar Estado de Tarea",
                    "7# - Eliminar Usuario",
                    "8# - Eliminar Tarea",
                    "9# - Salir"
                };

                foreach (var n in acciones)
                {
                    Console.WriteLine(n);
                }

                Console.WriteLine("\nIngrese el número de la acción que desea realizar: \n");
                accion = int.Parse(Console.ReadLine());

                switch (accion)
                {
                    case 1:
                        ConsultarUsuarios();
                        break;
                    case 2:
                        ConsultarTareas();
                        break;
                    case 3:
                        InsertarUsuario();
                        break;
                    case 4:
                        InsertarTarea();
                        break;
                    case 5:
                        ModificarUsuario();
                        break;
                    case 6:
                        ModificarEstadoTarea();
                        break;
                    case 7:
                        EliminarUsuario();
                        break;
                    case 8:
                        EliminarTarea();
                        break;
                    case 9:
                        // Salgo.
                        break;
                    default:
                        Console.WriteLine("\n*************** Ingrese una opción válida ***************\n");
                        break;
                }

            } while (accion != 9);

        }

        static void ConsultarUsuarios()
        {
            var ctx = new TareaDbContext();
            var lista = ctx.Usuario.ToList();
            Console.WriteLine("\n-----> Usuarios en DB:\n");
            foreach (var item in lista)
            {
                Console.WriteLine($"ID {item.Id_User}: {item.User} ({item.Clave})");
            }
        }

        static void ConsultarTareas()
        {
            var ctx = new TareaDbContext();
            var lista = ctx.Tarea.ToList();
            Console.WriteLine("\n-----> Tareas en DB:\n");
            foreach (var item in lista)
            {
                Console.WriteLine($"Tarea: '{item.Titulo}' #{item.Id_Tarea}" +
                    $"\n ----------> Vencimiento: {item.Vencimiento} " +
                    $"\n ----------> Estimación: {item.Estimacion} " +
                    $"\n ----------> Responsable: {item.Responsable}" +
                    $"\n ----------> Estado: {item.Estado}\n");
            }
        }

        static void InsertarUsuario()
        {
            var ctx = new TareaDbContext();

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

        static void InsertarTarea()
        {
            var ctx = new TareaDbContext();

            Console.WriteLine("Título de la nueva tarea: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Vencimiento: ");
            DateTime vencimiento = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Estimación: ");
            int estimacion = int.Parse(Console.ReadLine());
            Console.WriteLine("Responsable: ");
            /*
             * Esto lo dejo para después porque tengo que ver cómo lo hago:
             * Recurso responsable = Recurso.Parse(Console.ReadLine());
             */

            // Ejemplo de tratamiento de excepciones:
            try
            {
                Console.WriteLine("Estado: ");
                bool estado = bool.Parse(Console.ReadLine());

                ctx.Set<Tarea>().Add(new Tarea
                {
                    Titulo = titulo,
                    Vencimiento = vencimiento,
                    Estimacion = estimacion,
                    // Cuando resuelva del tipo de dato ajusto esto:
                    Responsable = null,
                    Estado = estado,
                });
            }
            catch
            {
                Console.Write("\n¡ ¡ ¡ ¡ ¡ La tarea se guardará con el estado en FALSE ! ! ! ! !\n");

                ctx.Set<Tarea>().Add(new Tarea
                {
                    Titulo = titulo,
                    Vencimiento = vencimiento,
                    Estimacion = estimacion,
                    // Cuando resuelva del tipo de dato ajusto esto:
                    Responsable = null,
                    Estado = false,
                });
            }

            ctx.SaveChanges();
            Console.WriteLine("\n*************** GUARDADO ***************\n");
        }
        
        static void EliminarUsuario()
        {
            Console.WriteLine("\n¿Desea eliminar ingresando el nombre de usuario? Y/N");
            string accion = Console.ReadLine();
            if (accion == "Y")
            {
                Console.WriteLine("\nIngrese el nombre del usuario que desea borrar: ");
                string usuario = Console.ReadLine();

                var ctx = new TareaDbContext();
                var user = ctx.Usuario.Where(i => i.User == usuario).Single();
                ctx.Usuario.Remove(user);
                ctx.SaveChanges();
                Console.WriteLine("\n*************** ELIMINADO ***************\n");
            }
            else if (accion == "N")
            {
                Console.WriteLine("\nIngrese el ID del usuario que desea borrar: ");
                int usuarioID = int.Parse(Console.ReadLine());

                var ctx = new TareaDbContext();
                var user = ctx.Usuario.Where(i => i.Id_User == usuarioID).Single();
                ctx.Usuario.Remove(user);
                ctx.SaveChanges();
                Console.WriteLine("\n*************** ELIMINADO ***************\n");
            }
            else
            {
                Console.WriteLine("\n*************** Ingrese una opción válida ***************\n");
            }
        }

        static void EliminarTarea()
        {
            Console.WriteLine("\nIngrese el ID de la tarea que desea borrar: ");
            int tarea = int.Parse(Console.ReadLine());
            var ctx = new TareaDbContext();
            var task = ctx.Tarea.Where(i => i.Id_Tarea == tarea).Single();
            ctx.Tarea.Remove(task);
            ctx.SaveChanges();
            Console.WriteLine("\n*************** ELIMINADO ***************\n");
        }

        static void ModificarUsuario()
        {
            Console.WriteLine("\nIngrese el ID del usuario que desea modificar: ");
            int usuario = int.Parse(Console.ReadLine());
            var ctx = new TareaDbContext();
            /* Voy a recibir un único usuario porque paso como parámetro el ID,
             * dejo esta notación por si lo cambio más adelante.
             */
            var lista = ctx.Usuario.Where(i => i.Id_User == usuario).ToList();

            Console.WriteLine("Ingrese el nuevo nombre de usuario: ");
            string usuarioNuevo = Console.ReadLine();
            Console.WriteLine("Ingrese la clave numérica: ");
            int claveNueva = int.Parse(Console.ReadLine());

            lista[0].User = usuarioNuevo;
            lista[0].Clave = claveNueva;

            ctx.SaveChanges();
            Console.WriteLine("\n*************** MODIFICADO ***************\n");
        }

        static void ModificarEstadoTarea()
        {
            var ctx = new TareaDbContext();
            var lista = ctx.Tarea.ToList();

            int accion = 0;
            Console.WriteLine("\n¿Qué tareas desea visualizar?: \n1# - Activas \n2# - Inactivas \n3# - Todas\n");
            accion = int.Parse(Console.ReadLine());

            switch (accion)
            {
                case 1:
                    var listaActiva = ctx.Tarea.Where(i => i.Estado == true).ToList();
                    foreach (var item in listaActiva)
                    {
                        Console.WriteLine($"Tarea: '{item.Titulo}' #{item.Id_Tarea}" +
                            $"\n ----------> Vencimiento: {item.Vencimiento} " +
                            $"\n ----------> Estimación: {item.Estimacion} " +
                            $"\n ----------> Responsable: {item.Responsable}" +
                            $"\n ----------> Estado: {item.Estado}\n");
                    }
                    break;
                case 2:
                    var listaInactiva = ctx.Tarea.Where(i => i.Estado == false).ToList();
                    foreach (var item in listaInactiva)
                    {
                        Console.WriteLine($"Tarea: '{item.Titulo}' #{item.Id_Tarea}" +
                            $"\n ----------> Vencimiento: {item.Vencimiento} " +
                            $"\n ----------> Estimación: {item.Estimacion} " +
                            $"\n ----------> Responsable: {item.Responsable}" +
                            $"\n ----------> Estado: {item.Estado}\n");
                    }
                    break;
                case 3:
                    var listaCompleta = ctx.Tarea.ToList();
                    foreach (var item in listaCompleta)
                    {
                        Console.WriteLine($"Tarea: '{item.Titulo}' #{item.Id_Tarea}" +
                            $"\n ----------> Vencimiento: {item.Vencimiento} " +
                            $"\n ----------> Estimación: {item.Estimacion} " +
                            $"\n ----------> Responsable: {item.Responsable}" +
                            $"\n ----------> Estado: {item.Estado}\n");
                    }
                    break;
                case 4:
                    // Salgo.
                    break;
                default:
                    Console.WriteLine("\n*************** Opción Inválida ***************\n");
                    break;
            }

            Console.WriteLine("\nIngrese el ID de la tarea para cambiar su estado: ");
            int modificar = int.Parse(Console.ReadLine());
            
            var consulta = ctx.Tarea.Where(i => i.Id_Tarea == modificar).Single();
            bool estado = consulta.Estado;

            if (estado == true)
            {
                var task = ctx.Tarea.Where(i => i.Id_Tarea == modificar).Single();
                task.Estado = false;
                ctx.SaveChanges();
            }
            else if (estado == false)
            {
                var task = ctx.Tarea.Where(i => i.Id_Tarea == modificar).Single();
                task.Estado = true;
                ctx.SaveChanges();
            }
            else
            {
                Console.WriteLine("\nDefina el estado de la tarea: TRUE/FALSE\n");
                bool estadoActualizado = bool.Parse(Console.ReadLine());
                lista[modificar].Estado = estadoActualizado;
            }

            ctx.SaveChanges();
            Console.WriteLine("\n*************** MODIFICADO ***************\n");
        }
    }
}
