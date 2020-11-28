using Microsoft.EntityFrameworkCore;
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace ProyectoFinal.Data
{
    public class UsuarioService
    {
        private TaskDbContext context;

        public UsuarioService(TaskDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Usuario>> GetAll()
        {
            //return await context.Usuarios.ToListAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetAllUsuarios();
        }

        public async Task<Usuario> Get(int id)
        {
            //return await context.Usuarios.Where(i => i.Id_User == id).SingleAsync();
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GetUsuario(id);
        }

        public async Task<Usuario> Save(Usuario value)
        {
            /*
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
            */
            var remoteService = RestService.For<IRemoteService>("https://localhost:44350/api/");
            return await remoteService.GuardarUsuario(value);
        }

        public async Task<bool> Remove(int id)
        {
            var entidad = await context.Usuarios.Where(i => i.Id_User == id).SingleAsync();
            context.Usuarios.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
