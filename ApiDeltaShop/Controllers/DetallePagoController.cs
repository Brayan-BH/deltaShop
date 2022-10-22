using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/detallePago")]
    public class DetallePagoController : ControllerBase
    {
        private readonly MyDbContext db;

        public DetallePagoController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            var response = new Response();
            List<DetallePago> detallePagos = db.DetallePagos.ToList();
            var data = new Dictionary<string, object>()
            {
                {"detallePagos", detallePagos}
            };
            response.data = data;
            return Ok(response);
        }
    }
}
