using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _ProyectoFinal.Data
{
    public class TareaService
    {
        /*
        public Tarea[] GetTareas()
        {
            Tarea[] resultado = new Tarea[10];
            resultado[0] = new Tarea (1, "Tarea1", new DateTime (2020,10,30), 10, false);
            resultado[1] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, false);
            resultado[2] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, false);
            resultado[3] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, false);
            resultado[4] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, false);
            resultado[5] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, false);
            resultado[6] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, false);
            resultado[7] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, false);
            resultado[8] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, false);
            resultado[9] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, false);

            return resultado;
        }
        */

        private TaskDbContext context;

        public TareaService(TaskDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Tarea>> GetAll()
        {
            return await context.Tareas.ToListAsync();
        }
        public async Task<Tarea> Get(int id)
        {
            return await context.Tareas.Where(i => i.Id_Tarea == id).SingleAsync();
        }

        public async Task<Tarea> Save(Tarea value)
        {
            if (value.Id_Tarea == 0)
            {
                await context.Tareas.AddAsync(value);
            }
            else
            {
                context.Tareas.Update(value);
            }
            await context.SaveChangesAsync();
            return value;
        }

        public async Task<bool> Delete(int id)
        {
            var entidad = await context.Tareas.Where(i => i.Id_Tarea == id).SingleAsync();
            context.Tareas.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }

        public List<Tarea> ConsultarTareas()
        {
            var ctx = new TaskDbContext(); // Creo una instancia de contexto.
            var lista = ctx.Tareas.ToList(); // Traigo la lista de la DB.
            Console.WriteLine("\n-----> Tareas en DB:\n");
            return lista; // Retorno el valor de la función.
        }

        public void InsertarTarea()
        {
            var ctx = new TaskDbContext();

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

        public void EliminarTarea()
        {
            Console.WriteLine("\nIngrese el ID de la tarea que desea borrar: ");
            int tarea = int.Parse(Console.ReadLine());
            var ctx = new TaskDbContext();
            var task = ctx.Tareas.Where(i => i.Id_Tarea == tarea).Single();
            ctx.Tareas.Remove(task);
            ctx.SaveChanges();
            Console.WriteLine("\n*************** ELIMINADO ***************\n");
        }

        static void ModificarEstadoTarea()
        {
            var ctx = new TaskDbContext();
            var lista = ctx.Tareas.ToList();

            int accion = 0;
            Console.WriteLine("\n¿Qué tareas desea visualizar?: \n1# - Activas \n2# - Inactivas \n3# - Todas\n");
            accion = int.Parse(Console.ReadLine());

            switch (accion)
            {
                case 1:
                    var listaActiva = ctx.Tareas.Where(i => i.Estado == true).ToList();
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
                    var listaInactiva = ctx.Tareas.Where(i => i.Estado == false).ToList();
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
                    var listaCompleta = ctx.Tareas.ToList();
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

            var consulta = ctx.Tareas.Where(i => i.Id_Tarea == modificar).Single();
            bool estado = consulta.Estado;

            if (estado == true)
            {
                var task = ctx.Tareas.Where(i => i.Id_Tarea == modificar).Single();
                task.Estado = false;
                ctx.SaveChanges();
            }
            else if (estado == false)
            {
                var task = ctx.Tareas.Where(i => i.Id_Tarea == modificar).Single();
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
