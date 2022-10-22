using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/Operaciones")]
    public class OperacionController : ControllerBase
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
            var response = new Response();
            List<Operaciones> operaciones = db.Operaciones.ToList();
            var data = new Dictionary<string, object>()
            {
                {"operaciones", operaciones}
            };
            response.data = data;
            return Ok(response);
        }
    }
}
