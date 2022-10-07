using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int IdUsuarios { get; set; }
    }
}
