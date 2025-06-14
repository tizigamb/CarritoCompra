using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Carrito
    {
        public List<ItemCarrito> items { get; set; }

        public Carrito()
        {
            items = new List<ItemCarrito>();
        }

        public void contenido_carrito()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"Nombre: {item.producto.nombre}, Cantidad: {item.cantidad}, Precio unitario: {item.producto.precio}, Subtotal: {(item.cantidad >= 5 ? 0.85m * item.cantidad * item.producto.precio : item.cantidad * item.producto.precio)}");
            }
        }

        public decimal total_a_pagar()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                decimal subtotal = item.cantidad * item.producto.precio;

                if (item.cantidad >= 5)
                {
                    subtotal *= 0.85m;
                }

                total += subtotal;
            }

            total *= 1.21m;

            return total;
        }
    }
}
