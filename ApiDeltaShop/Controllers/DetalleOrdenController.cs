using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/DetalleOrden")]
    public class DetalleOrdenController : ControllerBase
    {
        private readonly MyDbContext db;

        public DetalleOrdenController(MyDbContext context)
        {
            db = context;
        }
        [HttpGet]
        [Route("")]

        public ActionResult Listar()
        {
            List<DetalleOrden> detalleOrden = db.DetalleOrdenes.ToList();
            return Ok(new {DetalleOrden = detalleOrden});
        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] DetalleOrden detalleOrdenes)
        {
            db.DetalleOrdenes.Add(detalleOrdenes);
            db.SaveChanges();
            return Ok(detalleOrdenes);

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Eliminar([FromRoute] int id)
        {
            DetalleOrden? detalleOrdenes = db.DetalleOrdenes
                .Where(d => d.idDetalleOrden == id)
                .FirstOrDefault();
            if (detalleOrdenes == null)
            {
                return NotFound(new { message = "DetalleOrden no encontrado con el id: " + id });

            }
            db.DetalleOrdenes.Remove(detalleOrdenes);
            db.SaveChanges();
            return NoContent();

        }

    }
}
