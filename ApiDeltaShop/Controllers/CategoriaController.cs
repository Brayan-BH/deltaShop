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
            return Ok(categorias);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult ObtenerPorId([FromRoute] int id)
        {

            Producto? producto = db.Productos
                .Where(c =>c.idProductos == id)
                .FirstOrDefault();
            if (producto == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + id });

            }
            return Ok(producto);

        }

    }
}
