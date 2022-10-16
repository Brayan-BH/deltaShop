﻿using ApiDeltaShop.MyDb.Contexts;
using ApiDeltaShop.MyDb.Tables;
using Microsoft.AspNetCore.Mvc;

namespace ApiDeltaShop.Controllers
{
    [Controller]
    [Route("/api/v1/roles")]
    public class RolController: ControllerBase
    {
        private readonly MyDbContext db;

        public RolController(MyDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Listar()
        {
            List<Rol> roles = db.Roles.ToList();
            return Ok(roles);

        }
    }
}