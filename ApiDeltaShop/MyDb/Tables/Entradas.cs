using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Entradas")]
    public class Entradas
    {
        [Key]
        public int idEntrada { get; set; }
        public DateTime fecha { get; set; }
        public float totalCosto { get; set; }
        public int idUsuarios { get; set; }
    }
}
