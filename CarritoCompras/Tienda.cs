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

        public void agregar_item_carrito(int id_producto, int cant)
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

        public void eliminar_item_carrito(int id_producto, int cant)
        {
            if (cant <= 0)
            {
                throw new ArgumentException("La cantidad no puede ser igual o menor a cero");
            }

            var item = carrito.items.FirstOrDefault(i => i.producto.id == id_producto);
            if (item == null)
            {
                throw new ArgumentException("El carrito no tiene ese producto");
            }

            carrito.items.Remove(item);
            if (item.cantidad > cant)
            {
                carrito.items.Add(new ItemCarrito(item.producto, item.cantidad - cant));
            }
        }

        public void generar_ticket(Carrito carrito)
        {
            if (carrito.items.Count == 0)
            {
                throw new InvalidOperationException("El carrito está vacío. No se puede generar un ticket.");
            }

            Ticket ticket = new Ticket(carrito);
            historial.Add(ticket);
            Console.WriteLine($"Ticket generado con ID: {ticket.id}, Fecha: {ticket.fecha}, Total: {ticket.total}");
            carrito.items.Clear(); // limpiar el cacharro
        }

        public void finalizar_compra(Carrito carrito)
        {
            foreach (var item in carrito.items)
            {
                var productoEnTienda = productos_existentes.FirstOrDefault(p => p.id == item.producto.id);
                if (productoEnTienda != null)
                {
                    if (productoEnTienda.stock >= item.cantidad)
                    {
                        productoEnTienda.stock -= item.cantidad;
                    }
                    else
                    {
                        throw new InvalidOperationException($"No hay suficiente stock para el producto {productoEnTienda.nombre}.");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"El producto con ID {item.producto.id} no existe en la tienda.");
                }
            }

            Console.WriteLine($"Pagaste ${carrito.total_a_pagar()}");
            generar_ticket(carrito);
        }

        public void mostrar_historial()
        {
            Console.WriteLine("\n");
            if (historial.Count == 0)
            {
                Console.WriteLine("No hay historial de compras.");
                return;
            }
            foreach (var ticket in historial)
            {
                Console.WriteLine($"Ticket ID: {ticket.id}, Fecha: {ticket.fecha}, Total: {ticket.total}");
                ticket.items_comprados.contenido_carrito();
            }
        }

        public void mostrar_ticket(int id_ticket)
        {
            var ticket = historial.FirstOrDefault(t => t.id == id_ticket);
            if (ticket == null)
            {
                throw new ArgumentException("El ticket no existe.");
            }

            Console.WriteLine($"Ticket ID: {ticket.id}, Fecha: {ticket.fecha}, Total: {ticket.total}");
            ticket.items_comprados.contenido_carrito();
        }
    }
}
