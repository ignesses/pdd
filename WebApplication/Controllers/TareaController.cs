﻿using Microsoft.AspNetCore.Http;
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
            if (valor.Id_Tarea == 0)
            {
                _context.Tareas.Add(valor);
            }
            else
            {
                _context.Tareas.Attach(valor);
                _context.Tareas.Update(valor);
            }

            _context.SaveChanges();
            return valor;
        }

    }
}