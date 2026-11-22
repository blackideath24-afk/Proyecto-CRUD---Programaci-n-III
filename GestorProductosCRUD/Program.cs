using System;

namespace GestorProductosCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            var servicio = new ProductoService();
            bool ejecutando = true;

            while (ejecutando)
            {
                Console.WriteLine("\n=== GESTOR DE PRODUCTOS (CRUD) ===");
                Console.WriteLine("1. Crear producto");
                Console.WriteLine("0. Salir");
                Console.Write("Selecciona una opción: ");
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del producto: ");
                        string nombre = Console.ReadLine() ?? "";
                        Console.Write("Precio: ");
                        decimal precio = decimal.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Stock: ");
                        int stock = int.Parse(Console.ReadLine() ?? "0");

                        servicio.CrearProducto(nombre, precio, stock);
                        Console.WriteLine("Producto agregado correctamente.");
                        break;

                    case "0":
                        ejecutando = false;
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}