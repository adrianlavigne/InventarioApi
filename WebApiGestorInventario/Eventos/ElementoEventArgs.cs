using System;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.Eventos
{
    public class ElementoEventArgs: EventArgs
    {
        public Producto Producto { get; set; }
    }
}