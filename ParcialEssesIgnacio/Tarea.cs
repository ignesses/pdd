using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcialEssesIgnacio
{
    // Paso como parámetro el nombre que quiero que le asigne a la tabla:
    [Table("Tarea")]
    public class Tarea
    {
        [Key]
        public int Id_Tarea { get; set; }
        public string Titulo { get; set; }
        public DateTime Vencimiento { get; set; }
        public int Estimacion { get; set; }
        public Recurso Responsable { get; set; }
        public bool Estado { get; set; }
    }
}
