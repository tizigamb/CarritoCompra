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

            menu_interactivo(verduleria, carniceria, panaderia);
        }

        public static void menu_interactivo(Tienda tienda1, Tienda tienda2, Tienda tienda3)
        {
            while (true)
            {
                Console.WriteLine("Seleccione una tienda:");
                Console.WriteLine("1. Verdulería");
                Console.WriteLine("2. Carnicería");
                Console.WriteLine("3. Panadería");
                Console.WriteLine("4. Salir");

                string opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1":
                        tienda1.menu_interactivo_tienda();
                        break;
                    case "2":
                        tienda2.menu_interactivo_tienda();
                        break;
                    case "3":
                        tienda3.menu_interactivo_tienda();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        break;
                }
            }
        }
    }
}