namespace ComprasService.Models
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerId { get; set; }
        public double Total { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}