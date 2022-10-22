using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/usuarioCliente")]
    public class UsuarioClienteController: ControllerBase
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
            List<UsuarioCliente> usuarioClientes = db.UsuarioClientes.ToList();
            return Ok(new {UsuarioClientes = usuarioClientes});

        }

        [HttpPost]
        [Route("")]
        public ActionResult Crear([FromBody] UsuarioCliente usuarioClientes)
        {
            db.UsuarioClientes.Add(usuarioClientes);
            db.SaveChanges();
           return Ok(usuarioClientes);

        }
    }
}
