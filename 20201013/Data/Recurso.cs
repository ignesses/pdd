using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _20201013.Data
{
    // Paso como parámetro el nombre que quiero que le asigne a la tabla:
    [Table("Recurso")]
    public class Recurso
    {
        [Key]
        public int Id_Recurso { get; set; }
        public string Nombre { get; set; }
        public Usuario Usuario { get; set; }

        public Recurso() { }

        public Recurso(int Id_Recurso, string Nombre,Usuario Usuario)
        {
            this.Id_Recurso = Id_Recurso;
            this.Nombre = Nombre;
            this.Usuario = Usuario;
        }

    }

}
