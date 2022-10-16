using ApiDeltaShop.MyDb.Tables;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ApiDeltaShop.MyDb.Contexts
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<DetalleOrden> DetalleOrdenes { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<UsuarioCliente> UsuarioClientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<DetallePago> DetallePagos { get; set; }
        public DbSet<DetalleEntrada> DetalleEntradas { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolOperacion> RolOperaciones { get; set; }
        public DbSet<Operaciones> Operaciones { get; set; }
        public DbSet<Modulo> Modulos { get; set; }

    }
}
