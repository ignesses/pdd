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
            return _context.Detalles.Include(i => i.Recurso).ToList();
        }

        [HttpGet("{id}")]
        public Detalle Get(int id)
        {
            return _context.Detalles.Where(i => i.Id_Detalle == id).Single();
        }

        [HttpPost]
        public Detalle Post(Detalle valor)
        {
            if (valor.Id_Detalle == 0)
            {
                _context.Detalles.Add(valor);
            }
            else
            {
                _context.Detalles.Attach(valor);
                _context.Detalles.Update(valor);
            }

            _context.SaveChanges();
            return valor;
        }
    }
}
