using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Ticket
    {
        public static int _ultimoId = 0;

        public DateTime fecha { get; set; }
        public int id { get; set; }
        public List<ItemCarrito> producto { get; set; }
        public decimal total { get; set; }

        public Ticket(List<ItemCarrito> producto)
        {
            this.id = ++_ultimoId;
            this.fecha = DateTime.Now;
            this.producto = producto;

            // calcular subtotal con descuento por cantidad
            decimal subtotal = producto.Sum(item =>
            {
                decimal itemSubtotal = item.producto.precio * item.cantidad;
                if (item.cantidad >= 5)
                {
                    itemSubtotal *= 0.85m;
                }
                return itemSubtotal;
            });
            this.total = subtotal * 1.21m;

            if (producto == null || !producto.Any())
            {
                throw new ArgumentException("El ticket debe contener al menos un producto.");
            }
        }
    }
}