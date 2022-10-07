using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("RolOperacion")]
    public class RolOperacion
    {
        [Key]
        public int idRolOperacion { get; set; }
        public int idRol { get; set; }
        public int idOperaciones { get; set; }


    }
}
