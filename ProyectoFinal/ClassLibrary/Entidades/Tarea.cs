using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary
{
    [Table("Tarea")]
    public class Tarea
    {
        [Key]
        public int Id_Tarea { get; set; }
        public string Titulo { get; set; }
        public DateTime Vencimiento { get; set; }
        public int Estimacion { get; set; }
        public int RecursoId { get; set; }
        public Recurso Recurso { get; set; }
        public string Estado { get; set; }

        public Tarea() { }
        public Tarea(int Id_Tarea, string Titulo, DateTime Vencimiento, int Estimacion, int RecursoId, Recurso Recurso, string Estado)
        {
            this.Id_Tarea = Id_Tarea;
            this.Titulo = Titulo;
            this.Vencimiento = Vencimiento;
            this.Estimacion = Estimacion;
            this.RecursoId = RecursoId;
            this.Recurso = Recurso;
            this.Estado = Estado;
        }

    }
}
