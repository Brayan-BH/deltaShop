using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/usuarioCliente")]
    public class UsuarioClienteController : ControllerBase
    {
        private readonly MyDbContext db;

        public UsuarioClienteController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            var response = new Response();
            List<UsuarioCliente> usuarioClientes = db.UsuarioClientes.ToList();
            var data = new Dictionary<string, object>()
            {
                {"usuarioClientes", usuarioClientes}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] UsuarioCliente usuarioClientes)
        {
            db.UsuarioClientes.Add(usuarioClientes);
            db.SaveChanges();
            return Ok(usuarioClientes);

        }

        [HttpPut]
        [Route("{idUsuarioCLiente}")]
        public ActionResult Actualizar([FromRoute] int idUsuarioCLiente, [FromBody] UsuarioCliente usuarioClientesDato)
        {
            UsuarioCliente? usuarioCliente = db.UsuarioClientes
                .Where(uc => uc.idCliente == idUsuarioCLiente)
                .FirstOrDefault();
            if (usuarioCliente == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + idUsuarioCLiente });

            }
            usuarioClientesDato.password = usuarioClientesDato.password;

            db.SaveChanges();
            return NoContent();

        }
    }
}
