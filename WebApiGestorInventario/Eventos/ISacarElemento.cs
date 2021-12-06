using System;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.Eventos
{
    public interface ISacarElemento
    {
        event EventHandler<ElementoEventArgs> ElementoSacado;

        void SacarDelInventario(Producto producto);
    }
}