using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/productos")]
    public class ProductoController : ControllerBase
    {
        private readonly MyDbContext db;
        //Acceso a las base de datos ya no setea la configuracion a cada rato
        public ProductoController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("/get/a-productos/")]
        public ActionResult Listar()
        {
            var response = new Response();
            List<Producto> productos = db.Productos.ToList();
            var data = new Dictionary<string, object>()
            {
                {"productos", productos}
            };
            response.data = data;
            return Ok(response);

        }

        [HttpGet]
        [Route("/get/o-producto/{id}")]
        public ActionResult ObtenerPorId([FromRoute] int id)
        {
            var response = new Response();
            //Nulable(?) => Puede ser un producto o nulo 
            Producto? productos = db.Productos
                .Where(p => p.idProductos == id)
                .FirstOrDefault();

            if (productos == null)
            {
                return NotFound(new { message = "Producto no encontrado con el id: " + id });

            }
            var data = new Dictionary<string, object>()
            {
                {"productos", productos}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpPost]
        [Route("/create/productos/")]
        public ActionResult Crear([FromBody] Producto productos)
        {
            var response = new Response();

            db.Productos.Add(productos);
            db.SaveChanges();
            var data = new Dictionary<string, object>()
            {
                {"productos", productos}
            };
            response.data = data;
            return Ok(response);

        }

        [HttpPut]
        [Route("/update/producto/{id}")]
        public ActionResult Actualizar([FromRoute] int id, [FromBody] Producto productoDatos)
        {
            var response = new Response();
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
            var data = new Dictionary<string, object>()
            {
                {"productos", productoDatos}
            };
            response.data = data;
            return Ok(response);
        }

        // [HttpDelete]
        // [Route("{id}")]
        // public ActionResult Eliminar([FromRoute] int id)
        // {
        //     Producto? producto = db.Productos
        //         .Where(p => p.idProductos == id)
        //         .FirstOrDefault();
        //     if (producto == null)
        //     {
        //         return NotFound(new { message = "Producto no encontrado con el id: " + id });

        //     }
        //     db.Productos.Remove(producto);
        //     db.SaveChanges();
        //     return NoContent();

        // }
    }
}
