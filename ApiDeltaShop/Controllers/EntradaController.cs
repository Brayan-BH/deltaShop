using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/entradas")]
    public class EntradaController: ControllerBase
    {
        private readonly MyDbContext db;
        public EntradaController(MyDbContext context)
        {
            db = context;
        }
        [HttpGet]
        [Route("")]

        public ActionResult Listar()
        {
            List<Entrada> entradas = db.Entradas.ToList();
            return Ok(new {data = entradas});
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Actualizar([FromRoute] int id ,[FromBody] Entrada entradaDatos)
        {
            Entrada? entradas = db.Entradas
                .Where(e => e.idEntrada == id)
                .FirstOrDefault();
            if (entradas == null)
            {
                return NotFound(new { message = "Domicilio no encontrado con el id: " + id });

            }
            entradas.totalCosto = entradaDatos.totalCosto;

            db.SaveChanges();
            return NoContent();

        }
    }
}
