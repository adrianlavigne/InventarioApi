using System;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.Eventos
{
    public class SacarElemento : ISacarElemento
    {
        public event EventHandler<ElementoEventArgs> ElementoSacado;

        public void SacarDelInventario(Producto producto)
        {
            //TO-DO Eliminar de la lista del inventario
            Console.WriteLine("Se saca el producto del inventario");

            OnElementoSacado(producto);
        }

        private void OnElementoSacado(Producto producto)
        {
            ElementoSacado?.Invoke(this, new ElementoEventArgs() { Producto = producto });
        }
    }
}