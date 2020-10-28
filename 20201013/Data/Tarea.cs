using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _20201013.Data
{
    [Table("Tarea")]
    public class Tarea
    {

        [Key]
        public int Id_Tarea { get; set; }
        public string Titulo { get; set; }
        public DateTime Vencimiento { get; set; }
        public int Estimacion { get; set; }
        public string Responsable { get; set; }
        public string Estado { get; set; }

        public Tarea() { }
        public Tarea(int Id_Tarea, string titulo, DateTime vencimiento, int estimacion, string estado)
        {
            this.Id_Tarea = Id_Tarea;
            this.Titulo = titulo;
            this.Vencimiento = vencimiento;
            this.Estimacion = estimacion;
            this.Estado = estado;
        }

    }
}
