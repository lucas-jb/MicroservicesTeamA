namespace PruebaSearch.Models
{
    public class OrderItem
    {
        public string OrderId { get; set; }
        public int Id { get; set; }
        public string ProductoId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Producto Producto { get; set; }

    }
}
