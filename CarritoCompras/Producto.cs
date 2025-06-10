using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Producto
    {
        public static int _ultimoId = 0;

        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public Categoria categoria { get; set; }

        public Producto(string nombre, decimal precio, int stock, Categoria categoria)
        {
            if(precio < 0)
            {
                throw new ArgumentException("El precio no puede ser negativo.");
            }

            if (stock < 0)
            {
                throw new ArgumentException("El stock no puede ser negativo.");
            }

            this.id = ++_ultimoId;
            this.nombre = nombre;
            this.precio = precio;
            this.stock = stock;
            this.categoria = categoria;
        }
    }
}
