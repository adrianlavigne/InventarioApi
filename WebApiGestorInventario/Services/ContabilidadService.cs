using WebApiGestorInventario.Eventos;

namespace WebApiGestorInventario.Services
{
    public class ContabilidadService
    {
        public void OnElementoSacado(object source, ElementoEventArgs eventArgs)
        {
            //To-Do Actualizar Contabilidad una vez sacado el elemento del inventario
            System.Console.WriteLine("Contabilidad actualizada después de sacar un elemento");
        }

        public void OnElementoCaducado(object source, ElementoEventArgs eventArgs)
        {
            //To-Do Actualizar Contabilidad una vez caducado un elemento del inventario
            System.Console.WriteLine("Contabilidad actualizada al caducar un elemento");
        }
    }
}