using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("DetalleEntrada")]
    public class DetalleEntrada
    {
        [Key]
        public int iddetalleEntrada { get; set; }
        public int idEntrada { get; set; }
        public int cantidad { get; set; }
        public int idProducto { get; set; }
        public float PrecioCosto { get; set; }
        public float PrecioVenta { get; set; }

    }
}
