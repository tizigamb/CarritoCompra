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
    }
}
