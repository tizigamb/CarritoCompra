using System;

namespace CarritoCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            Tienda verduleria = new Tienda();

            verduleria.categorias_existentes.Add(new Categoria("Verduras", "Verduras frescas"));
            verduleria.categorias_existentes.Add(new Categoria("Frutas", "Frutas frescas"));


            verduleria.productos_existentes.Add(new Producto("Tomate", 100, 50, verduleria.categorias_existentes[0]));
            verduleria.productos_existentes.Add(new Producto("Lechuga", 80, 20, verduleria.categorias_existentes[0]));
            verduleria.productos_existentes.Add(new Producto("Zanahoria", 60, 40, verduleria.categorias_existentes[0]));


            verduleria.productos_existentes.Add(new Producto("Naranja", 120, 25, verduleria.categorias_existentes[1]));
            verduleria.productos_existentes.Add(new Producto("Banana", 90, 35, verduleria.categorias_existentes[1]));
            verduleria.productos_existentes.Add(new Producto("Manzana", 150, 30, verduleria.categorias_existentes[1]));

            Tienda carniceria = new Tienda();

            carniceria.categorias_existentes.Add(new Categoria("Carnes", "Carne de vaca"));
            carniceria.categorias_existentes.Add(new Categoria("Aves", "Carne de pollo"));
            carniceria.categorias_existentes.Add(new Categoria("Cerdo", "Carne de cerdo"));

            carniceria.productos_existentes.Add(new Producto("Asado", 2000, 10, carniceria.categorias_existentes[0]));
            carniceria.productos_existentes.Add(new Producto("Pollo", 1500, 15, carniceria.categorias_existentes[1]));
            carniceria.productos_existentes.Add(new Producto("Cerdo", 1800, 12, carniceria.categorias_existentes[2]));

            Tienda panaderia = new Tienda();

            panaderia.categorias_existentes.Add(new Categoria("Pan", "Pan recién hecho"));
            panaderia.categorias_existentes.Add(new Categoria("Facturas", "Productos de pastelería"));
            panaderia.categorias_existentes.Add(new Categoria("Café", "Café de máquina"));

            panaderia.productos_existentes.Add(new Producto("Pan", 50, 100, panaderia.categorias_existentes[0]));
            panaderia.productos_existentes.Add(new Producto("Bizcocho", 70, 60, panaderia.categorias_existentes[0]));

            panaderia.productos_existentes.Add(new Producto("Medialuna", 30, 80, panaderia.categorias_existentes[1]));
            panaderia.productos_existentes.Add(new Producto("Cañoncito de dulce de leche", 40, 50, panaderia.categorias_existentes[1]));

            panaderia.productos_existentes.Add(new Producto("Café en jarrita", 120, 200, panaderia.categorias_existentes[2]));
            panaderia.productos_existentes.Add(new Producto("Café cortado", 100, 150, panaderia.categorias_existentes[2]));
        }
    }
}