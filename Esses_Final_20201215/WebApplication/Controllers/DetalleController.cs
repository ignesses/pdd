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
    public class DetalleController : ControllerBase
    {
        private readonly DataContext _context;
        public DetalleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Detalle> Get()
        {
            return _context.Detalles.Include(i => i.Recurso).Include(i => i.Tarea).ToList();
        }

        [HttpGet("{id}")]
        public Detalle Get(int id)
        {
            return _context.Detalles.Where(i => i.Id_Detalle == id).Single();
        }

        [HttpGet("Filtro/{id}")]
        public List<Detalle> GetDetalleTarea(int id)
        {
            List<Detalle> detalles =  _context.Detalles.Include(i => i.Recurso).Include(i => i.Tarea).ToList();
            List<Detalle> filtroDetalles = detalles.FindAll(d => d.TareaId == id);
            return filtroDetalles;
        }

        [HttpPost]
        public Detalle Post(Detalle valor)
        {
            var local = _context.Detalles.Local.FirstOrDefault(e => e.Id_Detalle.Equals(valor.Id_Detalle));

            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            if (valor.Id_Detalle == 0)
                _context.Entry(valor).State = EntityState.Added;
            else
                _context.Entry(valor).State = EntityState.Modified;

            _context.SaveChanges();
            return valor;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var detalle = _context.Detalles.Where(i => i.Id_Detalle == id).Single();

            _context.Detalles.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
