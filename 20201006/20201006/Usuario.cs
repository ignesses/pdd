using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _20201006
{
    // Paso como parámetro el nombre que quiero que le asigne a la tabla:
    [Table("Usuario")]
    public class Usuario
    {
        [Key] // Data Notations, que modifica a la línea inmediatamente seguida.
        // Porque no respeta la convención de EntityFramework:
        // No se llama ni "Id" ni "Usuario_Id"
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }
        
        // Para usar un largo máximo:
        [MaxLength(50)]
        // Para usar un largo mínimo:
        [MinLength(10)]
        
        public string Nombre { get; set; }
        
        // Este campo es not null:
        [Required]
        // Paso el nombre de columna en la DB y el tipo de dato que necesito:
        [Column("Password", TypeName = "char(20)")]

        public int Clave { get; set; }

        // Esta propiedad no es un campo de la tabla (indico eso):
        [NotMapped]
        public string Imagen { get; set; }

    }
}
