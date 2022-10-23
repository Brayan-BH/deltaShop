using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/roles")]
    public class RolController : ControllerBase
    {
        private readonly MyDbContext db;

        public RolController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            var response = new Response();
            List<Rol> roles = db.Roles.ToList();
            var data = new Dictionary<string, object>()
            {
                {"roles", roles}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpPost]
        [Route("/create-rol/")]
        public ActionResult CrearRol([FromBody] Rol roles)
        {
            var response = new Response();
            db.Roles.Add(roles);
            db.SaveChanges();
            var data = new Dictionary<string, object>()
            {
                {"rol", roles}
            };
            response.data = data;
            return Ok(response);
        }
    }
}
