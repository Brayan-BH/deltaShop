using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int idProductos { get; set; }
        public string? nombre { get; set; } 
        public string? codigo { get; set; } 
        public string? modelo { get; set; } 
        public string? color { get; set;} 
        public decimal? precio { get; set;}
        public string? imagen { get; set;}
        public string? descripcion { get; set;} 
        public int? idCategoria { get; set; }
        public int? stock { get; set; }
        //public int idEstado { get; set; }

    }
}
