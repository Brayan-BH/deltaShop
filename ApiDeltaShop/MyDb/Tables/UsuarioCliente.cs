using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("UsuarioCliente")]
    public class UsuarioCliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nombres { get; set; } = "";
        public string apellidos { get; set; } = "";
        public string email { get; set; } = "";
        public string password { get; set; } = "";
        public string salt { get; set; } = "";

    }
}
