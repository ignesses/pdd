using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using WebApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Usuario> Get()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return _context.Usuarios.Where(i => i.Id_User == id).Single();
        }

        public static void Actualizar<T>(T elemento) where T : class
        {
            var ctx = new DataContext();
            ctx.Set<T>().Attach(elemento);
            ctx.Set<T>().Update(elemento);
            ctx.SaveChanges();
        }

        [HttpPost]
        public Usuario Post(Usuario valor)
        {
            if (valor.Id_User == 0)
            {
                _context.Usuarios.Add(valor);
            }
            else
            {
                _context.Set<Usuario>().Attach(valor);
                _context.Set<Usuario>().Update(valor);
                //_context.Usuarios.Attach(valor);
                //_context.Usuarios.Update(valor);

            }

            _context.SaveChanges();
            return valor;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = _context.Usuarios.Where(i => i.Id_User == id).Single();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
