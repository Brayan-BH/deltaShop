using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly MyDbContext db;

        public AuthController(MyDbContext context)
        {
            db = context;
        }

        [HttpPut]
        [Route("/login")]
        public ActionResult Login([FromBody] Usuario usuario)
        {
            // List<Usuario> usuarios = db.Usuarios.ToList();

            //Nulable(?) => Puede ser un producto o nulo 
            Usuario? usuarios = db.Usuarios
                .Where(u => u.user == usuario.user)
                .FirstOrDefault();

            if (usuarios == null)
            {
                return NotFound(new { message = "Usuario no encontrado con el id: "});

            }
            if (usuarios?.password != usuarios?.password)
            {
                return NotFound(new { message = "Usuario no encontrado con el id: "});
            }

            return Ok(usuario);



        }

    }
}
