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

        public Ticket(Carrito carrito)
        {
            if (carrito == null)
            {
                throw new ArgumentNullException(nameof(carrito), "El carrito no puede ser nulo.");
            }

            this.id = ++_ultimoId;
            this.fecha = DateTime.Now;
            this.total = carrito.total_a_pagar();
            this.items_comprados = new Carrito();

            foreach (var item in carrito.items) // me aseguro de que no se borre el contenido del carrito
            {
                var productoCopia = new Producto(
                    item.producto.nombre,
                    item.producto.precio,
                    item.producto.stock,
                    item.producto.categoria
                );
                productoCopia.id = item.producto.id;

                var itemCopia = new ItemCarrito(productoCopia, item.cantidad);
                this.items_comprados.items.Add(itemCopia);
            }
        }
    }
}