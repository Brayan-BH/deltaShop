using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/Modulos")]
    public class ModuloController: ControllerBase
    {
        private readonly MyDbContext db;

        public ModuloController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<Modulo> modulos = db.Modulos.ToList();
            return Ok(modulos);

        }
    }
}
