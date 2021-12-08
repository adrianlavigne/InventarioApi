﻿using System;

namespace WebApiGestorInventario.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CategoriaId { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public bool Disponibilidad { get; set; }

        public virtual Categoria Categoria { get; set; }

        public Producto()
        {
            Disponibilidad = true;
        }
    }
}