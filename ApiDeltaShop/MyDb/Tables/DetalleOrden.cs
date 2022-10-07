using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("DetalleOrden")]

    public class DetalleOrden
    {
        [Key]
        public int idDetalleOrden { get; set; }
        public int idOrden { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public float precio { get; set; }
        public int estado { get; set; }

    }
}
