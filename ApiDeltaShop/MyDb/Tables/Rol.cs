using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int idRol { get; set; }
        public string rol { get; set; } = "";


    }
}
