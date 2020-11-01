using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _20201013.Data
{
    // Paso como parámetro el nombre que quiero que le asigne a la tabla:
    [Table("Detalle")]
    public class Detalle
    {
        [Key]
        public int Id_Detalle { get; set; }
        public string Fecha { get; set; }
        public string Tiempo { get; set; }
        public Recurso Recurso { get; set; }
        public Tarea Tarea { get; set; }

        public Detalle() { }

        public Detalle(int Id_Detalle, string Fecha, string Tiempo, Recurso Recurso, Tarea Tarea)
        {
            this.Id_Detalle = Id_Detalle;
            this.Fecha = Fecha;
            this.Tiempo = Tiempo;
            this.Recurso = Recurso;
            this.Tarea = Tarea;
        }

    }
}
