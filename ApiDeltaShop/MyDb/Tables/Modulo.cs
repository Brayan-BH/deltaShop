using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Modulo")]

    public class Modulo
    {
        [Key]
        public int idModulo { get; set; }
        public string nombre { get; set; }

    }
}
