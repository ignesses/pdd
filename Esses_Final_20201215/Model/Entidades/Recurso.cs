using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("Recurso")]
    public class Recurso
    {
        [Key]
        public int Id_Recurso { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Recurso() { }

        public Recurso(int Id_Recurso, string Nombre, int UsuarioId, Usuario Usuario)
        {
            this.Id_Recurso = Id_Recurso;
            this.Nombre = Nombre;
            this.UsuarioId = UsuarioId;
            this.Usuario = Usuario;
        }

    }

}
