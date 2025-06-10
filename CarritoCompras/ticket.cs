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
            this.total = producto.Sum(item => item.producto.precio * item.cantidad) * 1.21m; // Asumiendo un IVA del 21%
            if (producto == null || !producto.Any())
            {
                throw new ArgumentException("El ticket debe contener al menos un producto.");
            }
        }
    }
}