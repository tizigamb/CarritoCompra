using System;

namespace CarritoCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            Tienda verduleria = new Tienda();
            verduleria.CargarDatos(args[0] == "1" ? 1 : 0);

            Tienda carniceria = new Tienda();
            carniceria.CargarDatos(args[1] == "2" ? 2 : 0);

            Tienda panaderia = new Tienda();
            panaderia.CargarDatos(args[2] == "3" ? 3 : 0);
        }
    }
}