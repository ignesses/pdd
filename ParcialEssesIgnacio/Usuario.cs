﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ParcialEssesIgnacio
{
    // Paso como parámetro el nombre que quiero que le asigne a la tabla:
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id_User { get; set; }

        // El campo User no puede ser null:
        [Required]
        // Largo máximo de clave:
        [MaxLength(20)]
        // Largo mínimo de clave:
        [MinLength(4)]
        public string User { get; set; }
        
        // El campo User no puede ser null:
        [Required]
        public int Clave { get; set; }
    }
}
