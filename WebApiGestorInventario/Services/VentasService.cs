using WebApiGestorInventario.Eventos;

namespace WebApiGestorInventario.Services
{
    public class VentasService
    {
        public void OnElementoSacado(object source, ElementoEventArgs eventArgs)
        {
            //To-Do Actualizar ventas
            System.Console.WriteLine("Dpto. Ventas actualizado después de sacar un elemento");
        }

        public void OnElementoCaducado(object source, ElementoEventArgs eventArgs)
        {
            //To-Do Actualizar Contabilidad una vez caducado un elemento del inventario
            System.Console.WriteLine("Dpto. Ventas actualizado después de caducar un elemento");
        }
    }
}