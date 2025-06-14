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
            this.items_comprados = carrito;
        }
    }
}