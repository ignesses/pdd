using Microsoft.EntityFrameworkCore;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using WebApplication.Data;

namespace ProyectoFinal.Data
{
    public class TareaService
    {
        private DataContext context;

        public TareaService(DataContext _context)
        {
            context = _context;
        }

        public async Task<List<Tarea>> GetAll()
        {
            //return await context.Tareas.Include(i=>i.Recurso).ToListAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetAllTareas();
        }

        public async Task<Tarea> Get(int id)
        {
            //return await context.Tareas.Where(i => i.Id_Tarea == id).SingleAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetTarea(id);
        }

        public async Task<Tarea> Save(Tarea value)
        {
            /*
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
            */

            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GuardarTarea(value);
        }

        

        public async Task<List<Recurso>> GetRecursos()
        {
            //return await context.Recursos.ToListAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetAllRecursos();

        }

        public async Task<bool> BorrarTarea(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            await remoteService.BorrarTarea(id);
            return true;
        }

        /***** FUERA DE USO *****/
        public async Task<bool> Remove(int id)
        {
            var entidad = await context.Tareas.Where(i => i.Id_Tarea == id).SingleAsync();
            context.Tareas.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }

    }

}
