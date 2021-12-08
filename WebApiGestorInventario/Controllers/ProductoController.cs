using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiGestorInventario.DAL;
using WebApiGestorInventario.Eventos;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.Controllers
{

    public class ProductoController : ApiController
    {
        private readonly InventarioContext context = new InventarioContext();

        public void CheckProductsObsolete()
        {
            foreach (var producto in context.Productos)
                if (producto.FechaCaducidad > DateTime.Today)
                {
                    var caducarElemento = new CaducarElemento();
                    caducarElemento.VerificarElemento(producto);
                }
        }

        // GET: api/Producto
        public IList<Producto> Get()
        {
            return context.Productos.Where(p => p.Disponibilidad).ToList();
        }

        // GET: api/Producto/5
        public Producto Get(int id)
        {
            return context.Productos.FirstOrDefault(p => p.Id == id);
        }

        // POST: api/Producto
        public void Post([FromBody]Producto producto)
        {
            context.Productos.Add(producto);
            context.SaveChanges();
        }

        // PUT: api/Producto
        public void Put([FromBody]string nombre)
        {
            var elementoABorrar = context.Productos.FirstOrDefault(p => p.Nombre == nombre);
            if (elementoABorrar != null)
            {
                elementoABorrar.Disponibilidad = false;
                var sacarElemento = new SacarElemento();
                sacarElemento.SacarDelInventario(elementoABorrar);
            }
            context.SaveChanges();
        }
    }
}
