using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Data
{
    public class RecursoService
    {
        private TaskDbContext context;

        public RecursoService(TaskDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Recurso>> GetAll()
        {
            return await context.Recursos.Include(i=>i.Usuario).ToListAsync();
        }

        public async Task<Recurso> Get(int id)
        {
            return await context.Recursos.Where(i => i.Id_Recurso == id).SingleAsync();
        }

        public async Task<Recurso> Save(Recurso value)
        {
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
        }

        public async Task<bool> Remove(int id)
        {
            var entidad = await context.Recursos.Where(i => i.Id_Recurso == id).SingleAsync();
            context.Recursos.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            return await context.Usuarios.ToListAsync();
        }

    }
}
