using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoCompras
{
    class Tienda
    {
        public List<Producto> productos_existentes { get; set; }
        public List<Categoria> categorias_existentes { get; set; }
        public List<Ticket> historial { get; set; }

        public Tienda()
        {
            productos_existentes = new List<Producto>();
            categorias_existentes = new List<Categoria>();
            historial = new List<Ticket>();
        }

        public void categorias_disponibles()
        {
            Console.WriteLine("\n");
            foreach (var categoria in categorias_existentes)
            {
                Console.WriteLine($"Categoria: {categoria.nombre}, Descripcion: {categoria.descripcion}");
            }
        }

        public void productos_disponibles()
        {
            Console.WriteLine("\n");
            foreach (var producto in productos_existentes)
            {
                Console.WriteLine($"ID: {producto.id}, Nombre: {producto.nombre}, Precio: {producto.precio}, Stock: {(producto.stock == 0 ? "Sin stock" : producto.stock.ToString())}, Categoria: {producto.categoria.nombre}");
            }
        }
    }
}
