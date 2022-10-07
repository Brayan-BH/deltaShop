using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    [Table("Domicilio")]
    public class Domicilio
    {
        [Key]
        public int idDomicilio { get; set; }
        public int idUsuario { get; set; }
        public string calle { get; set; }
        public string distrito { get; set; }
        public string provincia { get; set; }
        public string departamento { get; set; }
        public string pais { get; set; }
        public int codigoPostal { get; set; }
        public string referencia { get; set; }

    }
}
