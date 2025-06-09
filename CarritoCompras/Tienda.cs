using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Tienda
    {
        public List<Producto> productos_disponibles { get; set; }
        public List<Categoria> categorias_existentes { get; set; }

        public Tienda()
        {
            productos_disponibles = new List<Producto>();
            categorias_existentes = new List<Categoria>();
        }
    }
}
