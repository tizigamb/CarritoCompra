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
                Console.WriteLine($"Nombre: {item.producto.nombre}, Cantidad: {item.cantidad}, Precio unitario: {item.producto.precio}, Subtotal: {item.cantidad * item.producto.precio}");
            }
        }

        public decimal total_a_pagar()
        {
            decimal total = 0;
            foreach (var item in items)
            {
                total += item.cantidad * item.producto.precio;
            }
            return total;
        }
    }
}
