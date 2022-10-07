using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/rolOperaciones")]
    public class RolOperacionController: ControllerBase
    {
        private readonly MyDbContext db;

        public RolOperacionController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<RolOperacion> rolOperaciones = db.RolOperaciones.ToList();
            return Ok(rolOperaciones);

        }
    }
}
