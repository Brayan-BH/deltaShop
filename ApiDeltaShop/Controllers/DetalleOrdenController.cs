using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/DetalleOrden")]
    public class DetalleOrdenController: ControllerBase
    {
        private readonly MyDbContext db;

        public DetalleOrdenController(MyDbContext context)
        {
            db = context;
        }
        [HttpGet]
        [Route("")]

        public ActionResult Listar()
        {
            List<DetalleOrden> detalleOrden = db.DetalleOrdenes.ToList();
            return Ok(detalleOrden);
        }

    }
}
