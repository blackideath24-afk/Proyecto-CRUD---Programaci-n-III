namespace GestorProductosCRUD
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Nombre: {Nombre} | Precio: ${Precio:F2} | Stock: {Stock}";
        }
    }
}