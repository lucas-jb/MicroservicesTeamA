namespace ComprasService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProveedorId { get; set; }
        public double Total { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}