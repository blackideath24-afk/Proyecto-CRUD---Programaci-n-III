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
                Console.WriteLine("2. Listar productos");
                Console.WriteLine("3. Actualizar producto");
                Console.WriteLine("4. Eliminar producto");
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

                    case "2":
                        var lista = servicio.ObtenerTodos();
                        if (lista.Count == 0)
                        {
                            Console.WriteLine("No hay productos registrados.");
                        }
                        else
                        {
                            Console.WriteLine("\n--- Lista de Productos ---");
                            foreach (var p in lista)
                            {
                                Console.WriteLine(p);
                            }
                        }
                        break;

                    case "3":
                        Console.Write("ID del producto a actualizar: ");
                        int idEditar = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Nuevo nombre: ");
                        string nuevoNombre = Console.ReadLine() ?? "";
                        Console.Write("Nuevo precio: ");
                        decimal nuevoPrecio = decimal.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Nuevo stock: ");
                        int nuevoStock = int.Parse(Console.ReadLine() ?? "0");

                        if (servicio.ActualizarProducto(idEditar, nuevoNombre, nuevoPrecio, nuevoStock))
                            Console.WriteLine("Producto actualizado correctamente.");
                        else
                            Console.WriteLine("Producto no encontrado.");
                        break;

                    case "4":
                        Console.Write("ID del producto a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine() ?? "0");

                        if (servicio.EliminarProducto(idEliminar))
                            Console.WriteLine("Producto eliminado correctamente.");
                        else
                            Console.WriteLine("Producto no encontrado.");
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