using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/entradas")]
    public class EntradasController: ControllerBase
    {
        private readonly MyDbContext db;
        public EntradasController(MyDbContext context)
        {
            db = context;
        }
        [HttpGet]
        [Route("")]

        public ActionResult Listar()
        {
            List<Entradas> entradas = db.Entradas.ToList();
            return Ok(entradas);
        }
    }
}
