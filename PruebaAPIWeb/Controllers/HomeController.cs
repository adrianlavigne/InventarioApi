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
        private List<Producto> productos;

        public ActionResult Index()
        {
            if (Session["Productos"] == null)
            {
                productos = GetModelFromAPI();
                Session["Productos"] = productos;
            }
            else
                productos = (List<Producto>)Session["Productos"];

            return View(productos.Where(p => p.Disponibilidad).ToList());
        }

        private List<Producto> GetModelFromAPI()
        {
            using (var client = new HttpClient())
            {
                InitializeHttpClient(client);

                // Hace la llamada 
                var response = client.GetAsync("producto");
                response.Wait();

                // Si el servicio responde correctamente
                if (response.Result.IsSuccessStatusCode)
                {
                    // Lee el response y lo deserializa como una lista de Producto
                    var dataObjects = response.Result.Content.ReadAsAsync<List<Producto>>();
                    return dataObjects.Result;
                }
                // Sino devuelve lista vacía
                return new List<Producto>();
            }
        }

        private static void InitializeHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:50777/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            // Agrega el header Accept: application/json para recibir la data como json  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private bool PostProducto(Producto producto)
        {
            using (var client = new HttpClient())
            {
                InitializeHttpClient(client);

                var response = client.PostAsJsonAsync<Producto>("producto", producto);
                response.Wait();

                return response.Result.IsSuccessStatusCode;
            }
        }

        public ActionResult NuevoProducto()
        {
            var model = new Producto();
            return View(model);
        }

        [HttpPost]
        public ActionResult NuevoProducto(Producto producto)
        {
            productos = (List<Producto>)Session["Productos"];
            if (PostProducto(producto))
                productos.Add(producto);

            return View("Index", productos.Where(p => p.Disponibilidad).ToList());
        }

        private bool PutProductoPorNombre(string nombre)
        {
            using (var client = new HttpClient())
            {
                InitializeHttpClient(client);

                var response = client.PutAsJsonAsync<string>("producto", nombre);
                response.Wait();

                return response.Result.IsSuccessStatusCode;
            }
        }

        public ActionResult SacarProducto(string nombre)
        {
            productos = (List<Producto>)Session["Productos"];
            if (PutProductoPorNombre(nombre))
            {
                var producto = productos.Find(p => p.Nombre == nombre);
                if (producto != null) producto.Disponibilidad = false;
            }
                
            return View("Index", productos.Where(p => p.Disponibilidad).ToList());
        }
    }
}