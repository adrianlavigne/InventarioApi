using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiGestorInventario.DAL;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.Controllers
{
    public class CategoriaController : ApiController
    {
        private readonly InventarioContext context = new InventarioContext();

        // GET api/categoria
        public IList<Categoria> Get()
        {
            return context.Categorias.ToList();
        }

        // GET api/categoria/5
        public Categoria Get(int id)
        {
            return context.Categorias.FirstOrDefault(c => c.Id == id);
        }

        // POST api/categoria
        public void Post([FromBody] Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
        }

        // PUT api/categoria/5
        public void Put(int id, [FromBody] string value)
        {
            var cat = context.Categorias.FirstOrDefault(c => c.Id == id);
            cat.Nombre = value;
            context.SaveChanges();
        }

        // DELETE api/categoria/5
        public void Delete(int id)
        {
        }
    }
}