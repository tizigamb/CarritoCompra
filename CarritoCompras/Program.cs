using System;
using System.Security.Cryptography.X509Certificates;

namespace CarritoCompras
{
    class Program
    {
        static void Main(string[] args)
        {
            Tienda verduleria = new Tienda();
            verduleria.CargarDatos(int.Parse(args[0]));

            Tienda carniceria = new Tienda();
            carniceria.CargarDatos(int.Parse(args[1]));

            Tienda panaderia = new Tienda();
            panaderia.CargarDatos(int.Parse(args[2]));

            Console.Clear();
            menu_interactivo(verduleria, carniceria, panaderia);
        }

        public static void menu_interactivo(Tienda tienda1, Tienda tienda2, Tienda tienda3)
        {
            while (true)
            {
                Console.WriteLine("===== Tiendas =====");
                Console.WriteLine($"1. {tienda1.name}");
                Console.WriteLine($"2. {tienda2.name}");
                Console.WriteLine($"3. {tienda3.name}");
                Console.WriteLine($"4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        tienda1.menu_interactivo_tienda();
                        break;
                    case "2":
                        Console.Clear();
                        tienda2.menu_interactivo_tienda();
                        break;
                    case "3":
                        Console.Clear();
                        tienda3.menu_interactivo_tienda();
                        break;
                    case "4":
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        break;
                }
            }
        }
    }
}