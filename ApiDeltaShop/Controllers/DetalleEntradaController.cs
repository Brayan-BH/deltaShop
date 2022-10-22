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
            var response = new Response();
            List<DetalleEntrada> detalleEntradas = db.DetalleEntradas.ToList();
            var data = new Dictionary<string, object>()
            {
                {"detalleEntradas", detalleEntradas}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] DetalleEntrada detalleEntradas)
        {
            db.DetalleEntradas.Add(detalleEntradas);
            db.SaveChanges();
           return Ok(detalleEntradas);

        }
    }
}
