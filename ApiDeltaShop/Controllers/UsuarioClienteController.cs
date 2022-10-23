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
        [Route("/get/a-cli/")]
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
        [Route("/create/cli/")]
        public ActionResult Crear([FromBody] UsuarioCliente usuarioClientes)
        {
            var response = new Response();
            db.UsuarioClientes.Add(usuarioClientes);
            db.SaveChanges();
            var data = new Dictionary<string, object>()
            {
                {"usuarioClientes", usuarioClientes}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpPut]
        [Route("/update/o-clie/{idUsuarioCLiente}")]
        public ActionResult Actualizar([FromRoute] int idUsuarioCLiente, [FromBody] UsuarioCliente usuarioClientesDato)
        {
            var response = new Response();
            UsuarioCliente? usuarioClientes = db.UsuarioClientes
                .Where(uc => uc.idCliente == idUsuarioCLiente)
                .FirstOrDefault();
            if (usuarioClientes == null)
            {
                return NotFound(new { message = "Categoria no encontrado con el id: " + idUsuarioCLiente });

            }
            usuarioClientesDato.password = usuarioClientesDato.password;

            db.SaveChanges();
            var data = new Dictionary<string, object>()
            {
                {"usuarioClientes", usuarioClientesDato}
            };
            response.data = data;
            return Ok(response);
        }

        [HttpGet]
        [Route("/get/o-user-cli/{idUsuarioCLiente}")]
        public ActionResult ObtenerPorId([FromRoute] int idUsuarioCLiente)
        {
            var response = new Response();
            UsuarioCliente? usuarioClientes = db.UsuarioClientes
                .Where(uc => uc.idCliente == idUsuarioCLiente)
                .FirstOrDefault();
            if (usuarioClientes == null)
            {
                return NotFound(new { message = "Usuario Cliente no encontrado con el id: " + idUsuarioCLiente });

            }
            var data = new Dictionary<string, object>()
            {
                {"usuarios", usuarioClientes}
            };
            response.data = data;
            return Ok(response);
        }
    }
}
