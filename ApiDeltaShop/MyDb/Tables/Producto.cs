using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Productos")]
    public class Producto
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public string modelo { get; set; }
        public string color { get; set;}
        public int categoria_id { get; set; }
        public int estado_id { get; set; }

    }
}
