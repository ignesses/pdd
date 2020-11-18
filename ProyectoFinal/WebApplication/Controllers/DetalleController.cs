using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using WebApplication.Data;

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
            return _context.Detalles.ToList();
        }
    }
}
