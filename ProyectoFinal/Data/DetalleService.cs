using Microsoft.EntityFrameworkCore;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace ProyectoFinal.Data
{
    public class DetalleService
    {
        private TaskDbContext context;

        public DetalleService(TaskDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Detalle>> GetAll()
        {
            //return await context.Detalles.Include(i=>i.Recurso).ToListAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetAllDetalles();
        }

        public async Task<Detalle> Get(int id)
        {
            //return await context.Detalles.Where(i => i.Id_Detalle == id).SingleAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetDetalle(id);
        }

        public async Task<Detalle> Save(Detalle value)
        {
            /*
            if (value.Id_Detalle == 0)
            {
                await context.Detalles.AddAsync(value);
            }
            else
            {
                context.Detalles.Update(value);
            }
            await context.SaveChangesAsync();
            return value;
            */

            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GuardarDetalle(value);
        }

        public async Task<bool> Remove(int id)
        {
            var entidad = await context.Detalles.Where(i => i.Id_Detalle == id).SingleAsync();
            context.Detalles.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Recurso>> GetRecursos()
        {
            //return await context.Recursos.ToListAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetAllRecursos();
        }

    }
}
