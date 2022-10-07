using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("DetallePago")]
    public class DetallePago
    {
        [Key]
        public int idDetallePago { get; set; }
        public string metodoPago { get; set; }
        public DateTime fechaPago { get; set; }
        public string detalle { get; set; }

    }
}
