using Hangfire;
using Hangfire.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebApiGestorInventario.Helpers;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.Controllers
{
    
    public class ProductoController : ApiController
    {

        public IList<Producto> Productos
        {
            get { return GetProductos(); }
        }

        //Simulación de lectura de BD
        private IList<Producto> GetProductos()
        {
            var result = new List<Producto>();
            for (int i = 0; i < 20; i++)
            {
                Producto producto = new Producto()
                {
                    Id = i,
                    Nombre = "Producto" + i,
                    Tipo = "Tipo" + i % 5,
                    FechaCaducidad = DateTime.Today.AddDays(60),
                    Disponibilidad = true
                };
                result.Add(producto);
            }

            return result;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            var manager = new RecurringJobManager();
            manager.AddOrUpdate("CheckProductsObsolete", Job.FromExpression(() => CheckProductsObsolete()), Cron.Daily());
        }

        [HttpPatch]
        public void CheckProductsObsolete()
        {
            foreach (var producto in Productos)
                if (producto.FechaCaducidad > DateTime.Today)
                    NotificationHelper.Notificar(string.Format("El elemento {0} ha caducado", producto.Nombre));
        }

        // GET: api/Producto
        [HttpGet]
        public IList<Producto> Get()
        {
            return Productos.Where(p => p.Disponibilidad).ToList();
        }

        // GET: api/Producto/5
        [HttpGet]
        public Producto Get(int id)
        {
            return Productos.FirstOrDefault(p => p.Id == id);
        }

        // POST: api/Producto
        [HttpPost]
        public void Post([FromBody]Producto producto)
        {
            Productos.Add(producto);
        }

        // PUT: api/Producto
        [HttpPut]
        public void Put([FromBody]string nombre)
        {
            var elementoABorrar = Productos.FirstOrDefault(p => p.Nombre == nombre);
            if (elementoABorrar != null)
            {
                elementoABorrar.Disponibilidad = false;
                NotificationHelper.Notificar(string.Format("El elemento {0} se ha sacado del inventario.", elementoABorrar.Nombre));
            }
        }
    }
}
