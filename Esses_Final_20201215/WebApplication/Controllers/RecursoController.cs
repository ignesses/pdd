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
    public class RecursoController : ControllerBase
    {
        private readonly DataContext _context;
        public RecursoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Recurso> Get()
        {
            return _context.Recursos.Include(i => i.Usuario).ToList();
        }

        [HttpGet("{id}")]
        public Recurso Get(int id)
        {
            return _context.Recursos.Where(i => i.Id_Recurso == id).Single();
        }

        [HttpPost]
        public Recurso Post(Recurso valor)
        {
            var local = _context.Recursos.Local.FirstOrDefault(e => e.Id_Recurso.Equals(valor.Id_Recurso));

            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            if (valor.Id_Recurso == 0)
                _context.Entry(valor).State = EntityState.Added;
            else
                _context.Entry(valor).State = EntityState.Modified;

            _context.SaveChanges();
            return valor;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var recurso = _context.Recursos.Where(i => i.Id_Recurso == id).Single();

            _context.Recursos.Remove(recurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
