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
            return _context.Recursos.ToList();
        }
    }
}
