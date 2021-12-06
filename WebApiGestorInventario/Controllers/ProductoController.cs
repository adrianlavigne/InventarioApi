using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebApiGestorInventario.Eventos;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.Controllers
{

    public class ProductoController : ApiController
    {
        private IList<Producto> _productos { get; set; }

        public IList<Producto> Productos
        {
            get { return GetProductos(); }
        }

        //Simulación de lectura de BD
        private IList<Producto> GetProductos()
        {
            if (_productos == null)
            {
                _productos = new List<Producto>();
                for (int i = 1; i <= 20; i++)
                {
                    Producto producto = new Producto()
                    {
                        Id = i,
                        Nombre = "Producto" + i,
                        Tipo = "Tipo" + i % 5,
                        FechaCaducidad = DateTime.Today.AddDays(60),
                        Disponibilidad = true
                    };
                    _productos.Add(producto);
                }
            }

            return _productos;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }

        [HttpPatch]
        public void CheckProductsObsolete()
        {
            foreach (var producto in Productos)
                if (producto.FechaCaducidad > DateTime.Today)
                {
                    var caducarElemento = new CaducarElemento();
                    caducarElemento.VerificarElemento(producto);
                }
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
            if (_productos == null)
                _productos = new List<Producto>();
            _productos.Add(producto);
        }

        // PUT: api/Producto
        [HttpPut]
        public void Put([FromBody]string nombre)
        {
            var elementoABorrar = Productos.FirstOrDefault(p => p.Nombre == nombre);
            if (elementoABorrar != null)
            {
                elementoABorrar.Disponibilidad = false;
                var sacarElemento = new SacarElemento();
                sacarElemento.SacarDelInventario(elementoABorrar);
            }
        }
    }
}
