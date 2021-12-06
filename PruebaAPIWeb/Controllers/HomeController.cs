using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using WebApiGestorInventario.Models;

namespace PruebaAPIWeb.Controllers
{
    public class HomeController : Controller
    {
        private static HttpClient _client { get; set; }
        public ActionResult Index()
        {
            InitializeHttpClient();
            List<Producto> result = GetProductsFromAPI();

            return View(result.Where(p => p.Disponibilidad).ToList());
        }

        private static List<Producto> GetProductsFromAPI()
        {
            List<Producto> result = new List<Producto>();

            // Hace la llamada 
            var response = _client.GetAsync("producto");
            response.Wait();

            // Si el servicio responde correctamente
            if (response.Result.IsSuccessStatusCode)
            {
                // Lee el response y lo deserializa como una lista de Producto
                var dataObjects = response.Result.Content.ReadAsAsync<List<Producto>>();
                result = dataObjects.Result;
            }

            return result;
        }

        private static void InitializeHttpClient()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:50777/api/")
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            // Agrega el header Accept: application/json para recibir la data como json  
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult NuevoProducto()
        {
            var model = new Producto();
            return View(model);
        }

        [HttpPost]
        public ActionResult NuevoProducto(Producto producto)
        {
            var response = _client.PostAsJsonAsync<Producto>("producto", producto);
            response.Wait();

            if (!response.Result.IsSuccessStatusCode)
                Console.WriteLine(string.Format("No se ha podido agregar el producto {0} al inventario.", producto.Nombre));

            return View("Index", GetProductsFromAPI());
        }

        public ActionResult SacarProducto(string nombre)
        {
            var response = _client.PutAsJsonAsync<string>("producto", nombre);
            response.Wait();

            if (!response.Result.IsSuccessStatusCode)
                Console.WriteLine(string.Format("No se ha podido sacar el producto {0} del inventario.", nombre));

            return View("Index", GetProductsFromAPI());
        }
    }
}