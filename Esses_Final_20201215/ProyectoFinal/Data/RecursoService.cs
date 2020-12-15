using Microsoft.EntityFrameworkCore;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using WebApplication.Data;

namespace ProyectoFinal.Data
{
    public class RecursoService
    {
        private DataContext context;

        public RecursoService(DataContext _context)
        {
            context = _context;
        }

        public async Task<List<Recurso>> GetAll()
        {
            //return await context.Recursos.Include(i=>i.Usuario).ToListAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetAllRecursos();
        }

        public async Task<Recurso> Get(int id)
        {
            //return await context.Recursos.Where(i => i.Id_Recurso == id).SingleAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetRecurso(id);
        }

        public async Task<Recurso> Save(Recurso value)
        {
            /*
            if (value.Id_Recurso == 0)
            {
                await context.Recursos.AddAsync(value);
            }
            else
            {
                context.Recursos.Update(value);
            }
            await context.SaveChangesAsync();
            return value;
            */
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GuardarRecurso(value);
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            //return await context.Usuarios.ToListAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetAllUsuarios();
        }

        public async Task<bool> BorrarRecurso(int id)
        {
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            await remoteService.BorrarRecurso(id);
            return true;
        }

        /***** FUERA DE USO *****/
        public async Task<bool> Remove(int id)
        {
            var entidad = await context.Recursos.Where(i => i.Id_Recurso == id).SingleAsync();
            context.Recursos.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
