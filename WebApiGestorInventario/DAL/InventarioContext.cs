using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.DAL
{
    public class InventarioContext: DbContext
    {
        public InventarioContext() : base("InventarioContext")
        {

        }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}