using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Detalle")]
    public class Detalle
    {
        [Key]
        public int Id_Detalle { get; set; }
        public DateTime Fecha { get; set; }
        public string Tiempo { get; set; }
        public int RecursoId { get; set; }
        public Recurso Recurso { get; set; }
        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }

        public Detalle() { }

        public Detalle(int Id_Detalle, DateTime Fecha, string Tiempo, int RecursoId, Recurso Recurso, int TareaId, Tarea Tarea)
        {
            this.Id_Detalle = Id_Detalle;
            this.Fecha = Fecha;
            this.Tiempo = Tiempo;
            this.RecursoId = RecursoId;
            this.Recurso = Recurso;
            this.TareaId = TareaId;
            this.Tarea = Tarea;
        }

    }
}
