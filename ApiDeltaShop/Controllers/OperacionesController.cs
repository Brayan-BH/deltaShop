using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/Operaciones")]
    public class OperacionController: ControllerBase
    {
        private readonly MyDbContext db;

        public OperacionController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<Operaciones> operaciones = db.Operaciones.ToList();
            return Ok(new {Operaciones = operaciones});

        }
    }
}
