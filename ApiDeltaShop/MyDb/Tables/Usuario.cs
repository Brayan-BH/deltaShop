using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int IdUsuarios { get; set; }
        public string user { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int idRol { get; set; }
    }
}
