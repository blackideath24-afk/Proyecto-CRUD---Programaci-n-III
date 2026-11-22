using System.Collections.Generic;

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
    }
}