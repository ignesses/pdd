using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Model;
using WebApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly DataContext _context;
        public TareaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Tarea> Get()
        {
            return _context.Tareas.Include(i => i.Recurso).ToList();
        }

        [HttpGet("{id}")]
        public Tarea Get(int id)
        {
            return _context.Tareas.Where(i => i.Id_Tarea == id).Single();
        }

        [HttpPost]

        public Tarea Post(Tarea valor)
        {
            var local = _context.Tareas.Local.FirstOrDefault(e => e.Id_Tarea.Equals(valor.Id_Tarea));

            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            if (valor.Id_Tarea == 0)
                _context.Entry(valor).State = EntityState.Added;
            else
                _context.Entry(valor).State = EntityState.Modified;

            _context.SaveChanges();
            return valor;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tarea = _context.Tareas.Where(i => i.Id_Tarea == id).Single();

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
