using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/detalleEntrada")]
    public class DetalleEntradaController: ControllerBase
    {
        private readonly MyDbContext db;

        public DetalleEntradaController(MyDbContext context)
        {
            db = context;
        }
        [HttpGet]
        [Route("")]

        public ActionResult Listar()
        {
            List<DetalleEntrada> detalleEntradas = db.DetalleEntradas.ToList();
            return Ok(new {data = detalleEntradas});
        }
    }
}
