using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Operaciones")]

    public class Operaciones
    {
        [Key]
        public int idOperaciones { get; set; }
        public string nombreOperacion { get; set; }
        public int idModulo { get; set; }

    }
}
