using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebApiGestorInventario.Models;

namespace WebApiGestorInventario.DAL
{
    public class InventarioInitializer : DropCreateDatabaseIfModelChanges<InventarioContext>
    {
        protected override void Seed(InventarioContext context)
        {
            var categorias = new List<Categoria>
            {
                new Categoria{ Id = 1, Nombre = "Bebidas"},
                new Categoria{ Id = 2, Nombre = "Lácteos"},
                new Categoria{ Id = 3, Nombre = "Frutas y verduras"},
                new Categoria{ Id = 4, Nombre = "Dulces"},
                new Categoria{ Id = 5, Nombre = "Conservas"},
                new Categoria{ Id = 6, Nombre = "Carnes"},
                new Categoria{ Id = 7, Nombre = "Congelados"},
                new Categoria{ Id = 8, Nombre = "Salsas"},
                new Categoria{ Id = 9, Nombre = "Panes"},
                new Categoria{ Id = 10, Nombre = "Pescados"},
            };

            categorias.ForEach(c => context.Categorias.Add(c));
            context.SaveChanges();

            var productos = new List<Producto>
            {
                new Producto{ Id=1, Nombre="Leche entera", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 2 },
                new Producto{ Id=2, Nombre="Queso de cabra", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 2 },
                new Producto{ Id=3, Nombre="Coca Cola 1L", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 1 },
                new Producto{ Id=4, Nombre="Nestea 500ml", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 1 },
                new Producto{ Id=5, Nombre="Tomates ensalada", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 3 },
                new Producto{ Id=6, Nombre="Cebollinos", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 3 },
                new Producto{ Id=7, Nombre="Atún fresco", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 10 },
                new Producto{ Id=8, Nombre="Atún en lata Pack3", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 5 },
                new Producto{ Id=9, Nombre="Solomillo de cerdo", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 6 },
                new Producto{ Id=10, Nombre="Baguette", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 9 },
                new Producto{ Id=11, Nombre="Pan de barra", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 9 },
                new Producto{ Id=12, Nombre="Tarta de queso", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 4 },
                new Producto{ Id=13, Nombre="Tiramisú", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 4 },
                new Producto{ Id=14, Nombre="Yogurt de fresa 1l", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 2 },
                new Producto{ Id=15, Nombre="Salsa de soja", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 8 },
                new Producto{ Id=16, Nombre="Salsa barbacoa", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 8 },
                new Producto{ Id=17, Nombre="Sardinas en lata", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 5 },
                new Producto{ Id=18, Nombre="Zanahoria", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 3 },
                new Producto{ Id=19, Nombre="Manzana Golden", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 3 },
                new Producto{ Id=20, Nombre="Bananas", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 3 },
                new Producto{ Id=21, Nombre="Pulpo congelado 1kg", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 7 },
                new Producto{ Id=22, Nombre="Filete de res(1A)", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 6 },
                new Producto{ Id=23, Nombre="Langostino congelado", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 7 },
                new Producto{ Id=24, Nombre="Pande molde", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 9 },
                new Producto{ Id=25, Nombre="Pan de semillas", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 9 },
                new Producto{ Id=26, Nombre="Fanta 2L", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 1 },
                new Producto{ Id=27, Nombre="Vino Blanco", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 1 },
                new Producto{ Id=28, Nombre="Vino tinto", FechaCaducidad=DateTime.Parse("2022-09-01"), CategoriaId = 1 },

            };

            productos.ForEach(p => context.Productos.Add(p));
            context.SaveChanges();
        }
    }
}