namespace ComprasService.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int Id { get; set; }
        public string ProductoId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
