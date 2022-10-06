using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Estado")]
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }
        public string estado { get; set; }
    }
}
