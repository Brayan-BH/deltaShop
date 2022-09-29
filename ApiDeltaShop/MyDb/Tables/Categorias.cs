using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Categorias")]
    public class Categorias
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
    }
}
