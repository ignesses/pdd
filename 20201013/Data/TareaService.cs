using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20201013.Data
{
    public class TareaService
    {
        public Tarea[] GetTareas()
        {
            Tarea[] resultado = new Tarea[10];
            resultado[0] = new Tarea (1, "Tarea1", new DateTime (2020,10,30), 10, "false");
            resultado[1] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, "false");
            resultado[2] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, "false");
            resultado[3] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, "false");
            resultado[4] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, "false");
            resultado[5] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, "false");
            resultado[6] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, "false");
            resultado[7] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, "false");
            resultado[8] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, "false");
            resultado[9] = new Tarea(1, "Tarea1", new DateTime(2020, 10, 30), 10, "false");

            return resultado;
        }
    }
}
