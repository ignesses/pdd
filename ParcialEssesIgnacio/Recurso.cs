using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcialEssesIgnacio
{
    // Paso como parámetro el nombre que quiero que le asigne a la tabla:
    [Table("Recurso")]
    public class Recurso
    {
        [Key]
        public int Id_Recurso { get; set; }
        public string Nombre { get; set; }
        public Usuario Usuario { get; set; }
    }
}
