using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComprasService.Models
{
    [Table("OrderItem", Schema = "OrderItemsSchema")]
    public class OrderItem
    {
        [Column("OrderId", TypeName = "int")]
        public int OrderId { get; set; }

        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Column("ProductoId", TypeName = "int")]
        public int ProductoId { get; set; }

        [Required]
        [Column("Quantity", TypeName = "int")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("Price", TypeName = "decimal(18,4)")]
        public double Price { get; set; }
    }
}