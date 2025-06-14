using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Tienda
    {
        public List<Producto> productos_existentes { get; set; }
        public List<Categoria> categorias_existentes { get; set; }
        public List<Ticket> historial { get; set; }
        public Carrito carrito { get; set; }

        public Tienda()
        {
            productos_existentes = new List<Producto>();
            categorias_existentes = new List<Categoria>();
            historial = new List<Ticket>();
            carrito = new Carrito();
        }

        public void categorias_disponibles()
        {
            Console.WriteLine("\n");
            foreach (var categoria in categorias_existentes)
            {
                Console.WriteLine($"Categoria: {categoria.nombre}, Descripcion: {categoria.descripcion}");
            }
        }

        public void productos_disponibles()
        {
            Console.WriteLine("\n");
            foreach (var producto in productos_existentes)
            {
                Console.WriteLine($"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio}, Stock: {(producto.stock == 0 ? "Sin stock" : producto.stock.ToString())}, Categoria: {producto.categoria.nombre}");
            }
        }

        public void productos_filtrados(string nombre_categoria)
        {
            Console.WriteLine("\n");
            var productos_filtrados = productos_existentes.Where(p => p.categoria.nombre.Equals(nombre_categoria, StringComparison.OrdinalIgnoreCase)).ToList();
            if (productos_filtrados.Count == 0)
            {
                Console.WriteLine("No hay productos disponibles en esta categoria.");
                return;
            }
            foreach (var producto in productos_filtrados)
            {
                Console.WriteLine($"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio}, Stock: {(producto.stock == 0 ? "Sin stock" : producto.stock.ToString())}, Categoria: {producto.categoria.nombre}");
            }
        }

        public void agregar_carrito(int id_producto, int cant)
        {
            var producto_filtrado = productos_existentes.Where(p => p.id.Equals(id_producto)).FirstOrDefault();
            if (producto_filtrado == null)
            {
                throw new ArgumentException("El codigo del producto debe existir");
            }
            if (cant <= 0)
            {
                throw new ArgumentException("La cantidad no puede ser igual o menor a cero");
            }
            carrito.items.Add(new ItemCarrito(producto_filtrado, cant));
        }
    }
}
