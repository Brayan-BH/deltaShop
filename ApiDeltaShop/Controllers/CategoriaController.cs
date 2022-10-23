using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/categorias")]
    public class CategoriaController : ControllerBase
    {
        //Acceso a las base de datos ya no setea la configuracion a cada rato
        private readonly MyDbContext db;
        public CategoriaController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("/get/a-cat/")]
        public ActionResult ListarAll()
        {
            var response = new Response();
            List<Categorias> categorias = db.Categorias.ToList();
            var data = new Dictionary<string, object>()
            {
                {"categorias", categorias}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpGet]
        [Route("/get/o-cat/{id}")]
        public ActionResult ObtenerPorId([FromRoute] int id)
        {
            var response = new Response();
            Categorias? categorias = db.Categorias
                .Where(c => c.idCategoria == id)
                .FirstOrDefault();
            if (categorias == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + id });

            }
            var data = new Dictionary<string, object>()
            {
                {"categorias", categorias}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpPost]
        [Route("/create/cat/")]
        public ActionResult Crear([FromBody] Categorias categorias)
        {
            var response = new Response();

            db.Categorias.Add(categorias);
            db.SaveChanges();

            var data = new Dictionary<string, object>()
            {
                {"categorias", categorias}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpPut]
        [Route("/update/cat/{idCategoria}")]
        public ActionResult Actualizar([FromRoute] int idCategoria, [FromBody] Categorias categoriaDatos)
        {
            var response = new Response();
            Categorias? categorias = db.Categorias
                .Where(c => c.idCategoria == idCategoria)
                .FirstOrDefault();
            if (categorias == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + idCategoria });

            }
            categorias.nombreCategoria = categoriaDatos.nombreCategoria;

            db.SaveChanges();
            var data = new Dictionary<string, object>()
            {
                {"categorias", categoriaDatos}
            };
            response.data = data;
            return Ok(response);
        }

        // [HttpDelete]
        // [Route("{id}")]
        // public ActionResult Eliminar([FromRoute] int id)
        // {
        //     Categorias? categorias = db.Categorias
        //         .Where(c => c.idCategoria == id)
        //         .FirstOrDefault();
        //     if (categorias == null)
        //     {
        //         return NotFound(new { message = "Categoria no encontrado con el id: " + id });

        //     }
        //     db.Categorias.Remove(categorias);
        //     db.SaveChanges();
        //     return NoContent();

        // }
    }
}
