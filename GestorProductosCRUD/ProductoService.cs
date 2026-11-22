using System.Collections.Generic;
using System.Linq;

namespace GestorProductosCRUD
{
    public class ProductoService
    {
        private readonly List<Producto> _productos = new List<Producto>();
        private int _siguienteId = 1;

        public void CrearProducto(string nombre, decimal precio, int stock)
        {
            var producto = new Producto
            {
                Id = _siguienteId++,
                Nombre = nombre,
                Precio = precio,
                Stock = stock
            };
            _productos.Add(producto);
        }

        public List<Producto> ObtenerTodos()
        {
            return _productos;
        }

        public bool ActualizarProducto(int id, string nuevoNombre, decimal nuevoPrecio, int nuevoStock)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return false;

            producto.Nombre = nuevoNombre;
            producto.Precio = nuevoPrecio;
            producto.Stock = nuevoStock;
            return true;
        }

        public bool EliminarProducto(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null) return false;

            _productos.Remove(producto);
            return true;
        }
    }
}