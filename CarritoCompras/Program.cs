using System;

namespace CarritoCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Tienda verduleria = new Tienda();

            verduleria.categorias_existentes.Add(new Categoria("Verduras", "Verduras frescas"));
            verduleria.categorias_existentes.Add(new Categoria("Frutas", "Frutas frescas"));

            Producto tomate = new Producto("Tomate", 100, 50, verduleria.categorias_existentes[0]);
            Producto lechuga = new Producto("Lechuga", 80, 20, verduleria.categorias_existentes[0]);
            Producto zanahoria = new Producto("Zanahoria", 60, 40, verduleria.categorias_existentes[0]);
            
            Producto naranja = new Producto("Naranja", 120, 25, verduleria.categorias_existentes[1]);
            Producto banana = new Producto("Banana", 90, 35, verduleria.categorias_existentes[1]);
            Producto manzana = new Producto("Manzana", 150, 30, verduleria.categorias_existentes[1]);

        }
    }
}
