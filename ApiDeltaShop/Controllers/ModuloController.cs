using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/Modulos")]
    public class ModuloController : ControllerBase
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
            var response = new Response();
            List<Modulo> modulos = db.Modulos.ToList();
            var data = new Dictionary<string, object>()
            {
                {"modulos", modulos}
            };
            response.data = data;
            return Ok(response);
        }
    }
}
