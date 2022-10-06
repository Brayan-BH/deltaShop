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
        public DbSet<DetalleOrden> DetalleOrden { get; set; }

    }
}
