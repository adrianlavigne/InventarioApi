using System;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.Eventos
{
    public class CaducarElemento : ICaducarElemento
    {
        public event EventHandler<ElementoEventArgs> ElementoCaducado;

        public void VerificarElemento(Producto producto)
        {
            //TO-DO Verificar caducidad del producto
            Console.WriteLine("Se verifica la caducidad del producto");

            OnElementoCaducado(producto);
        }

        private void OnElementoCaducado(Producto producto)
        {
            ElementoCaducado?.Invoke(this, new ElementoEventArgs() { Producto = producto });
        }
    }
}