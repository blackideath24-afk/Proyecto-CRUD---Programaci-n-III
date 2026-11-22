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
                        string nombre = LeerTextoNoVacio("Nombre del producto: ");
                        decimal precio = LeerDecimalValido("Precio: ");
                        int stock = LeerEnteroValido("Stock: ");

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
                        int idEditar = LeerEnteroValido("ID del producto a actualizar: ");
                        string nuevoNombre = LeerTextoNoVacio("Nuevo nombre: ");
                        decimal nuevoPrecio = LeerDecimalValido("Nuevo precio: ");
                        int nuevoStock = LeerEnteroValido("Nuevo stock: ");

                        if (servicio.ActualizarProducto(idEditar, nuevoNombre, nuevoPrecio, nuevoStock))
                            Console.WriteLine("Producto actualizado correctamente.");
                        else
                            Console.WriteLine("Producto no encontrado.");
                        break;

                    case "4":
                        int idEliminar = LeerEnteroValido("ID del producto a eliminar: ");

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

        static string LeerTextoNoVacio(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entrada))
                    return entrada.Trim();

                Console.WriteLine("Error: El campo no puede estar vacío.");
            }
        }

        static decimal LeerDecimalValido(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor >= 0)
                    return valor;

                Console.WriteLine("Error: Ingresa un número decimal válido (mayor o igual a 0).");
            }
        }

        static int LeerEnteroValido(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(), out int valor) && valor >= 0)
                    return valor;

                Console.WriteLine("Error: Ingresa un número entero válido (mayor o igual a 0).");
            }
        }
    }
}