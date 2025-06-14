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

            Producto tomate = new Producto("Tomate", 100, 50, verduleria.categorias_existentes[0]);
            Producto lechuga = new Producto("Lechuga", 80, 20, verduleria.categorias_existentes[0]);
            Producto zanahoria = new Producto("Zanahoria", 60, 40, verduleria.categorias_existentes[0]);

            Producto naranja = new Producto("Naranja", 120, 25, verduleria.categorias_existentes[1]);
            Producto banana = new Producto("Banana", 90, 35, verduleria.categorias_existentes[1]);
            Producto manzana = new Producto("Manzana", 150, 30, verduleria.categorias_existentes[1]);

            verduleria.productos_existentes.Add(tomate);
            verduleria.productos_existentes.Add(lechuga);
            verduleria.productos_existentes.Add(zanahoria);

            verduleria.productos_existentes.Add(naranja);
            verduleria.productos_existentes.Add(banana);
            verduleria.productos_existentes.Add(manzana);

            Tienda carniceria = new Tienda();

            carniceria.categorias_existentes.Add(new Categoria("Carnes", "Carne de vaca"));
            carniceria.categorias_existentes.Add(new Categoria("Aves", "Carne de pollo"));
            carniceria.categorias_existentes.Add(new Categoria("Cerdo", "Carne de cerdo"));

            Producto asado = new Producto("Asado", 2000, 10, carniceria.categorias_existentes[0]);

            Producto pollo = new Producto("Pollo", 1500, 15, carniceria.categorias_existentes[1]);

            Producto cerdo = new Producto("Cerdo", 1800, 12, carniceria.categorias_existentes[2]);

            carniceria.productos_existentes.Add(asado);
            carniceria.productos_existentes.Add(pollo);
            carniceria.productos_existentes.Add(cerdo);

            Tienda panaderia = new Tienda();

            panaderia.categorias_existentes.Add(new Categoria("Pan", "Pan recién hecho"));
            panaderia.categorias_existentes.Add(new Categoria("Facturas", "Productos de pastelería"));
            panaderia.categorias_existentes.Add(new Categoria("Café", "Café de máquina"));

            Producto pan = new Producto("Pan", 50, 100, panaderia.categorias_existentes[0]);
            Producto bizcocho = new Producto("Bizcocho", 70, 60, panaderia.categorias_existentes[0]);

            Producto medialuna = new Producto("Medialuna", 30, 80, panaderia.categorias_existentes[1]);
            Producto cañoncito = new Producto("Cañoncito de dulce de leche", 40, 50, panaderia.categorias_existentes[1]);

            Producto cafe_jarrita = new Producto("Café en jarrita", 120, 200, panaderia.categorias_existentes[2]);
            Producto cafe_cortado = new Producto("Café cortado", 100, 150, panaderia.categorias_existentes[2]);

            panaderia.productos_existentes.Add(pan);
            panaderia.productos_existentes.Add(bizcocho);

            panaderia.productos_existentes.Add(medialuna);
            panaderia.productos_existentes.Add(cañoncito);

            panaderia.productos_existentes.Add(cafe_jarrita);
            panaderia.productos_existentes.Add(cafe_cortado);
    }
}
