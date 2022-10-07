using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Orden")]
    public class Orden
    {
        [Key]
        public int idOrden { get; set; }
        public string idCliente { get; set; }
        public float total { get; set; }
        public string horaCierre { get; set; }
        public string horaOrden { get; set; }
        public DateTime fecha { get; set; }
        public char estado { get; set; }
        public int idDomicilio { get; set; }
        public int idDetallePago { get; set; }

    }
}
