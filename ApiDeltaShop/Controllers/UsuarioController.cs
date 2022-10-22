using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly MyDbContext db;

        public UsuarioController(MyDbContext context)
        {
            db = context;
        }
        //Devuelve toddos los usuarios
        [HttpGet]
        [Route("/get/a-user")]
        public ActionResult Listar()
        {
            var response = new Response();
            List<Usuario> usuarios = db.Usuarios.ToList();
            var data = new Dictionary<string, object>()
            {
                {"usuarios", usuarios}
            };
            response.data = data;
            return Ok(response);

        }
        //Registra  los usuarios
        [HttpPost]
        [Route("/create-user")]
        public ActionResult Crear([FromBody] Usuario usuario)
        {
            db.Usuarios.Add(usuario);
            db.SaveChanges();
            return Ok(usuario);

        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Actualizar([FromRoute] int id, [FromBody] Usuario usuarioDatos)
        {
            Usuario? usuarios = db.Usuarios
                .Where(u => u.IdUsuarios == id)
                .FirstOrDefault();
            if (usuarios == null)
            {
                return NotFound(new { message = "Usuario no encontrado con el id: " + id });

            }
            usuarios.nombres = usuarioDatos.nombres;
            usuarios.apellidos = usuarioDatos.apellidos;
            usuarios.user = usuarioDatos.user;

            db.SaveChanges();
            return NoContent();

        }

        // [HttpGet]
        // [Route("{user}/{password}")]
        // public ActionResult ObtenerPorId([FromRoute] string user, [FromRoute] string password)
        // {
        //     Usuario model = new Usuario()
        //     {
        //         user = user,
        //         password = password
        //     };

        //     //Nulable(?) => Puede ser un producto o nulo 
        //     Usuario? usuario = db.Usuarios
        //         .Where(u => u.user == user)
        //         .FirstOrDefault();

        //     if (usuario == null)
        //     {
        //         return NotFound(new {message = "Usuario no encontrado con el id: "+ user});

        //     }
        //     return Ok(usuario);

        // }
    }
}
