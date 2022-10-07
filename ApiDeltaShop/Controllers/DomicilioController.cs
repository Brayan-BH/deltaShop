using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/domicilio")]
    public class DomicilioController: ControllerBase
    {
        private readonly MyDbContext db;

        public DomicilioController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<Domicilio> domicilios = db.Domicilios.ToList();
            return Ok(domicilios);

        }
    }
}
