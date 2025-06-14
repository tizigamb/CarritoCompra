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
        public string name { get; set; }

        public Tienda()
        {
            productos_existentes = new List<Producto>();
            categorias_existentes = new List<Categoria>();
            historial = new List<Ticket>();
            carrito = new Carrito();
            name = "Tienda";
        }

        public void categorias_disponibles()
        {
            foreach (var categoria in categorias_existentes)
            {
                Console.WriteLine($"Categoria: {categoria.nombre}, Descripcion: {categoria.descripcion}");
            }
        }

        public void productos_disponibles()
        {
            foreach (var producto in productos_existentes)
            {
                Console.WriteLine($"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio}, Stock: {(producto.stock == 0 ? "Sin stock" : producto.stock.ToString())}, Categoria: {producto.categoria.nombre}");
            }
        }

        public void productos_filtrados(string nombre_categoria)
        {
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

            Console.WriteLine($"Pagaste ${carrito.total_a_pagar()} (incluye IVA del 21%)");
            generar_ticket(carrito);
        }

        public void mostrar_historial()
        {
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

        public void CargarDatos(int flag)
        {
            switch (flag)
            {
                case 1:
                    this.name = "Verdulería";
                    this.categorias_existentes.Add(new Categoria("Verduras", "Verduras frescas"));
                    this.categorias_existentes.Add(new Categoria("Frutas", "Frutas frescas"));

                    this.productos_existentes.Add(new Producto("Tomate", 100, 50, this.categorias_existentes[0]));
                    this.productos_existentes.Add(new Producto("Lechuga", 80, 20, this.categorias_existentes[0]));
                    this.productos_existentes.Add(new Producto("Zanahoria", 60, 40, this.categorias_existentes[0]));

                    this.productos_existentes.Add(new Producto("Naranja", 120, 25, this.categorias_existentes[1]));
                    this.productos_existentes.Add(new Producto("Banana", 90, 35, this.categorias_existentes[1]));
                    this.productos_existentes.Add(new Producto("Manzana", 150, 30, this.categorias_existentes[1]));

                    break;
                case 2:
                    this.name = "Carnicería";
                    this.categorias_existentes.Add(new Categoria("Carnes", "Carne de vaca"));
                    this.categorias_existentes.Add(new Categoria("Aves", "Carne de pollo"));
                    this.categorias_existentes.Add(new Categoria("Cerdo", "Carne de cerdo"));

                    this.productos_existentes.Add(new Producto("Asado", 2000, 10, this.categorias_existentes[0]));
                    this.productos_existentes.Add(new Producto("Pollo", 1500, 15, this.categorias_existentes[1]));
                    this.productos_existentes.Add(new Producto("Cerdo", 1800, 12, this.categorias_existentes[2]));

                    break;
                case 3:
                    this.name = "Panadería";
                    this.categorias_existentes.Add(new Categoria("Pan", "Pan recién hecho"));
                    this.categorias_existentes.Add(new Categoria("Facturas", "Productos de pastelería"));
                    this.categorias_existentes.Add(new Categoria("Café", "Café de máquina"));

                    this.productos_existentes.Add(new Producto("Pan", 50, 100, this.categorias_existentes[0]));
                    this.productos_existentes.Add(new Producto("Bizcocho", 70, 60, this.categorias_existentes[0]));

                    this.productos_existentes.Add(new Producto("Medialuna", 30, 80, this.categorias_existentes[1]));
                    this.productos_existentes.Add(new Producto("Cañoncito de dulce de leche", 40, 50, this.categorias_existentes[1]));

                    this.productos_existentes.Add(new Producto("Café en jarrita", 120, 200, this.categorias_existentes[2]));
                    this.productos_existentes.Add(new Producto("Café cortado", 100, 150, this.categorias_existentes[2]));

                    break;
                default:
                    throw new ArgumentException("Flag no válido");
            }
        }

        public void menu_interactivo_tienda()
        {
            while (true)
            {
                Console.WriteLine($"\n--- Menú de la Tienda {name} ---");
                Console.WriteLine("1. Ver categorías disponibles");
                Console.WriteLine("2. Ver productos disponibles");
                Console.WriteLine("3. Ver productos filtrados por categoría");
                Console.WriteLine("4. Agregar un producto al carrito");
                Console.WriteLine("5. Eliminar un producto del carrito");
                Console.WriteLine("6. Ver contenido del carrito");
                Console.WriteLine("7. Ver total a pagar");
                Console.WriteLine("8. Historial de compras");
                Console.WriteLine("9. Ver ticket por ID");
                Console.WriteLine("10. Finalizar compra");
                Console.WriteLine("11. Salir al menú principal");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine() ?? "";

                try
                {
                    switch (opcion)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("===== Categorías Disponibles =====\n");
                            categorias_disponibles();
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("===== Productos Disponibles =====\n");
                            productos_disponibles();
                            break;
                        case "3":
                            Console.Clear();
                            Console.Write("Ingrese el nombre de la categoría: ");
                            string categoria = Console.ReadLine() ?? "";
                            productos_filtrados(categoria);
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("Si lleva 5 o más unidades, tendrá un descuento del 15%!!!");
                            Console.Write("Ingrese el ID del producto: ");
                            int idAgregar = int.Parse(Console.ReadLine() ?? "0");
                            Console.Write("Ingrese la cantidad: ");
                            int cantAgregar = int.Parse(Console.ReadLine() ?? "0");
                            agregar_item_carrito(idAgregar, cantAgregar);
                            Console.WriteLine("Producto agregado al carrito.");
                            break;
                        case "5":
                            Console.Clear();
                            Console.Write("Ingrese el ID del producto a eliminar: ");
                            int idEliminar = int.Parse(Console.ReadLine() ?? "0");
                            Console.Write("Ingrese la cantidad a eliminar: ");
                            int cantEliminar = int.Parse(Console.ReadLine() ?? "0");
                            eliminar_item_carrito(idEliminar, cantEliminar);
                            Console.WriteLine("Producto eliminado del carrito correctamente.");
                            break;
                        case "6":
                            Console.Clear();
                            Console.WriteLine("===== Contenido del Carrito =====\n");
                            if (carrito.items.Count == 0)
                            {
                                Console.WriteLine("El carrito está vacío.");
                            }
                            carrito.contenido_carrito();
                            break;
                        case "7":
                            Console.Clear();
                            Console.WriteLine($"Total a pagar: ${carrito.total_a_pagar()}");
                            break;
                        case "8":
                            Console.Clear();
                            Console.WriteLine("===== Historial de compras =====");
                            mostrar_historial();
                            break;
                        case "9":
                            Console.Clear();
                            Console.Write("Ingrese el ID del ticket: ");
                            int ticketId = int.Parse(Console.ReadLine() ?? "0");
                            mostrar_ticket(ticketId);
                            break;
                        case "10":
                            Console.Clear();
                            finalizar_compra(carrito);
                            break;
                        case "11":
                            Console.Clear();
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("\nOpción no válida, intente nuevamente.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
