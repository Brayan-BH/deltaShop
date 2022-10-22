using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/domicilio")]
    public class DomicilioController : ControllerBase
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
            var response = new Response();
            List<Domicilio> domicilios = db.Domicilios.ToList();
            var data = new Dictionary<string, object>()
            {
                {"domicilios", domicilios}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult ObtenerPorId([FromRoute] int id)
        {
            Domicilio? domicilios = db.Domicilios
                .Where(dom => dom.idDomicilio == id)
                .FirstOrDefault();

            if (domicilios == null)
            {
                return NotFound(new { message = "Domicilio no encontrado con el id: " + id });

            }
            return Ok(domicilios);

        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] Domicilio domicilios)
        {
            db.Domicilios.Add(domicilios);
            db.SaveChanges();
            return Ok(domicilios);

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Eliminar([FromRoute] int id)
        {
            Domicilio? domicilios = db.Domicilios
                .Where(dom => dom.idDomicilio == id)
                .FirstOrDefault();
            if (domicilios == null)
            {
                return NotFound(new { message = "DetalleOrden no encontrado con el id: " + id });

            }
            db.Domicilios.Remove(domicilios);
            db.SaveChanges();
            return NoContent();

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Actualizar([FromRoute] int id, [FromBody] Domicilio domicilioDatos)
        {
            Domicilio? domicilio = db.Domicilios
                .Where(p => p.idDomicilio == id)
                .FirstOrDefault();
            if (domicilio == null)
            {
                return NotFound(new { message = "Producto no encontrado con el id: " + id });

            }
            domicilio.calle = domicilioDatos.calle;
            domicilio.distrito = domicilioDatos.distrito;
            domicilio.provincia = domicilioDatos.provincia;
            domicilio.departamento = domicilioDatos.departamento;

            db.SaveChanges();
            return NoContent();

        }


    }
}
