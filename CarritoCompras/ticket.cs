using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Ticket
    {
        private static int _ultimoId = 0;

        public DateTime fecha { get; set; }
        public int id { get; set; }
        public decimal total { get; set; }
        public Carrito items_comprados { get; set; }

        public Ticket()
        {
            this.id = ++_ultimoId;
            this.fecha = DateTime.Now;
            this.total = 0;
            this.items_comprados = new Carrito();
        }

        /*public void agregar_producto(ItemCarrito producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto), "El producto no puede ser nulo.");
            }

            // Verificar si el producto ya existe en el ticket
            var itemExistente = productos.FirstOrDefault(p => p.producto.id == producto.producto.id);
            if (itemExistente != null)
            {
                itemExistente.cantidad += producto.cantidad;
            }
            else
            {
                productos.Add(producto);
            }

            // Recalcular total
            decimal subtotal = productos.Sum(item =>
            {
                decimal itemSubtotal = item.producto.precio * item.cantidad;
                if (item.cantidad >= 5)
                {
                    itemSubtotal *= 0.85m;
                }
                return itemSubtotal;
            });
            this.total = subtotal * 1.21m;
        }

        public void total_a_pagar()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n" + total);
        }

        public void contenido_carrito()
        {
            foreach (var item in productos)
            {
                Console.WriteLine($"Nombre: {item.producto.nombre}, Cantidad: {item.cantidad}, Precio unitario: {item.producto.precio}, Subtotal: {item.cantidad * item.producto.precio}");
            }
        }*/
    }
}