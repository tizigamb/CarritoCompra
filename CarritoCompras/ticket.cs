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
        public List<ItemCarrito> historial { get; set; }
        public decimal total { get; set; }

        public Ticket(List<ItemCarrito> historial)
        {
            this.id = ++_ultimoId;
            this.fecha = DateTime.Now;
            this.historial = historial;
            this.total = historial.Sum(item => item.producto.precio * item.cantidad);
        }
    }
}