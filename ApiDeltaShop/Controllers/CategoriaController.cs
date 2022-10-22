using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/categorias")]
    public class CategoriaController: ControllerBase
    {
        //Acceso a las base de datos ya no setea la configuracion a cada rato
        private readonly MyDbContext db;
        public CategoriaController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult ListarAll()
        {
            List<Categorias> categorias = db.Categorias.ToList();
            return Ok(new{dataCategoria = categorias});
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult ObtenerPorId([FromRoute] int id)
        {

            Categorias? categorias = db.Categorias
                .Where(c =>c.idCategoria == id)
                .FirstOrDefault();
            if (categorias == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + id });

            }
            return Ok(categorias);

        }
        
        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] Categorias categoria)
        {
            db.Categorias.Add(categoria);
            db.SaveChanges();
            return Ok(categoria);

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Actualizar([FromRoute] int id, [FromBody] Categorias categoriaDatos)
        {
            Categorias? categorias = db.Categorias
                .Where(c => c.idCategoria == id)
                .FirstOrDefault();
            if (categorias == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + id });

            }
            categorias.nombreCategoria = categoriaDatos.nombreCategoria;

            db.SaveChanges();
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Eliminar([FromRoute] int id)
        {
            Categorias? categorias = db.Categorias
                .Where(c => c.idCategoria == id)
                .FirstOrDefault();
            if (categorias == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + id });

            }
            db.Categorias.Remove(categorias);
            db.SaveChanges();
            return NoContent();

        }
    }
}
