using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/orden")]
    public class OrdenController: ControllerBase
    {
        private readonly MyDbContext db;

        public OrdenController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<Orden> ordenes = db.Ordenes.ToList();
            return Ok(new {data = ordenes});

        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] Orden ordenes)
        {
            db.Ordenes.Add(ordenes);
            db.SaveChanges();
            return Ok(ordenes);

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Actualizar([FromRoute] int id, [FromBody] Orden ordeneDatos)
        {
            Orden? ordenes = db.Ordenes
                .Where(o => o.idOrden == id)
                .FirstOrDefault();
            if (ordenes == null)
            {
                return NotFound(new { message = "Orden no encontrado con el id: " + id });

            }
            ordeneDatos.total = ordeneDatos.total;
            ordeneDatos.estado = ordeneDatos.estado;

            db.SaveChanges();
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Eliminar([FromRoute] int id)
        {
            Orden? ordenes = db.Ordenes
                .Where(o => o.idOrden == id)
                .FirstOrDefault();
            if (ordenes == null)
            {
                return NotFound(new { message = "Orden no encontrado con el id: " + id });

            }
            db.Ordenes.Remove(ordenes);
            db.SaveChanges();
            return NoContent();

        }
    }
}
