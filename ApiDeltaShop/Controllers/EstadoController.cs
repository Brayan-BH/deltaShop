using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("api/v1/estado")]
    public class EstadoController: ControllerBase
    {
        //Acceso a las base de datos ya no setea la configuracion a cada rato
        private readonly MyDbContext db;
        public EstadoController (MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult ListarAll()
        {
            List<Estado> estados = db.Estados.ToList();
            return Ok(new {data = estados});
        }

          
        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] Estado estado)
        {
            db.Estados.Add(estado);
            db.SaveChanges();
            return Ok(estado);

        }
    }
}
