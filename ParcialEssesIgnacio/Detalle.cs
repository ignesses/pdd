using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcialEssesIgnacio
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
    }
}
