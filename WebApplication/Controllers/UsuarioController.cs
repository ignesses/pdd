using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using WebApplication.Data;

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

        [HttpPost]
        public Usuario Post(Usuario valor)
        {
            if (valor.Id_User == 0)
            {
                _context.Usuarios.Add(valor);
            }
            else
            {
                _context.Usuarios.Attach(valor);
                _context.Usuarios.Update(valor);
            }

            _context.SaveChanges();
            return valor;
        }
    }
}
