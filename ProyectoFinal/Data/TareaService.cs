﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Data
{
    public class TareaService
    {
        private TaskDbContext context;

        public TareaService(TaskDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Tarea>> GetAll()
        {
            return await context.Tareas.Include(i=>i.Recurso).ToListAsync();
        }

        public async Task<Tarea> Get(int id)
        {
            return await context.Tareas.Where(i => i.Id_Tarea == id).SingleAsync();
        }

        public async Task<Tarea> Save(Tarea value)
        {
            if (value.Id_Tarea == 0)
            {
                await context.Tareas.AddAsync(value);
            }
            else
            {
                context.Tareas.Update(value);
            }
            await context.SaveChangesAsync();
            return value;
        }

        public async Task<bool> Remove(int id)
        {
            var entidad = await context.Tareas.Where(i => i.Id_Tarea == id).SingleAsync();
            context.Tareas.Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Recurso>> GetRecursos()
        {
            return await context.Recursos.ToListAsync();
        }

    }

}
