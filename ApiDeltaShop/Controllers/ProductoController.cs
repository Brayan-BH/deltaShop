using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/productos")]
    public class ProductoController: ControllerBase
    {
        private readonly MyDbContext db;
        //Acceso a las base de datos ya no setea la configuracion a cada rato
        public ProductoController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<Producto> productos = db.Productos.ToList();
            return Ok(productos);

        }
    }
}
