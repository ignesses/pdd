using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id_User { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string User { get; set; }

        [Required]
        //[NotMapped]
        public int Clave { get; set; }

        public Usuario() { }

        public Usuario(int Id_User, string User, int Clave)
        {
            this.Id_User = Id_User;
            this.User = User;
            this.Clave = Clave;
        }

    }
}
