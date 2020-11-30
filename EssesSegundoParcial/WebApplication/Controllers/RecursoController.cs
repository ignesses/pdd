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
            if (valor.Id_Recurso == 0)
            {
                _context.Recursos.Add(valor);
            }
            else
            {
                _context.Recursos.Attach(valor);
                _context.Recursos.Update(valor);
            }

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
