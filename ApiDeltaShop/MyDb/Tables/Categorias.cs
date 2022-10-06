using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Categorias")]
    public class Categorias
    {
        [Key]
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
    }
}
