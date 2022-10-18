using System.Text;
using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Jose;
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
        public ActionResult Login([FromBody] usuarioAuth auth)
        {
            var response = new Response();
            //Nulable(?) => Puede ser nulo 
            Usuario? usuarios = db.Usuarios
                .Where(u => u.user == auth.user)
                .FirstOrDefault();

            if (usuarios == null)
            {
                response.statusCode = 404;
                response.message = "User does not exist";
                return Ok(response);

            }
            if (usuarios?.password != auth?.password)
            {
                response.statusCode = 404;
                response.message = "User does not exist";
                return Ok(response);
            }

            //Creacion del diccionario para el acceso del usuario
            var payload = new Dictionary<string, object>()
            {

                {"id","id"},
                {"rol","rol"},
                //token expiration
                { "exp", DateTime.Now.AddHours(5) }
            };

            var secretKey = Encoding.ASCII.GetBytes("admindb");
            string token = Jose.JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);

            // usuario.password = token;
            var data = new Dictionary<string, object>()
            {
                {"token", token}
            };

            response.data = data;
            return Ok(response);

        }
    }
}
