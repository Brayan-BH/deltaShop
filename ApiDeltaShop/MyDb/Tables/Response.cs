using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDeltaShop.MyDb.Tables
{
    public class Response
    {
        public int statusCode { get; set; } = 200;
        public string message { get; set; } = "Success";
        public Dictionary<string, object> data { get; set; } = new Dictionary<string, object>();
    }
}
