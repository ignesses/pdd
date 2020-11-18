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
    public class TipoTareaController : ControllerBase
    {
        private readonly DataContext _context;
        public TipoTareaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<TipoTarea> Get()
        {
            return _context.TipoTareas.ToList();
        }
    }
}
