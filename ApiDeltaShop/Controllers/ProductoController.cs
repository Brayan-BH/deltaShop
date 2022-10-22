using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/productos")]
    public class ProductoController: ControllerBase
    {
        private readonly MyDbContext db;
        //Acceso a las base de datos ya no setea la configuracion a cada rato
        public ProductoController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<Producto> productos = db.Productos.ToList();
            return Ok(new{data = productos});

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult ObtenerPorId([FromRoute] int id)
        {
            //Nulable(?) => Puede ser un producto o nulo 
            Producto? producto = db.Productos
                .Where(p => p.idProductos == id)
                .FirstOrDefault();

            if (producto == null)
            {
                return NotFound(new {message = "Producto no encontrado con el id: "+ id});

            }
            return Ok(producto);

        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] Producto producto)
        {
            db.Productos.Add(producto);
            db.SaveChanges();
           return Ok(producto);

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Actualizar([FromRoute] int id ,[FromBody] Producto productoDatos)
        {
            Producto? producto = db.Productos
                .Where(p => p.idProductos == id)
                .FirstOrDefault();
            if (producto == null)
            {
                return NotFound(new { message = "Producto no encontrado con el id: " + id });

            }
            producto.nombre = productoDatos.nombre;
            producto.codigo = productoDatos.codigo;
            producto.modelo = productoDatos.modelo;

            db.SaveChanges();
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Eliminar([FromRoute] int id)
        {
            Producto? producto = db.Productos
                .Where(p => p.idProductos == id)
                .FirstOrDefault();
            if (producto == null)
            {
                return NotFound(new { message = "Producto no encontrado con el id: " + id });

            }
            db.Productos.Remove(producto);
            db.SaveChanges();
            return NoContent();

        }
    }
}
