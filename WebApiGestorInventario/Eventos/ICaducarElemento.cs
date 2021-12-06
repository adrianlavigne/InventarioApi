using System;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.Eventos
{
    public interface ICaducarElemento
    {
        event EventHandler<ElementoEventArgs> ElementoCaducado;

        void VerificarElemento(Producto producto);
    }
}