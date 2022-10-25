using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaSearch.Models
{
    [Table("Order")]

    public class Order
    {
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column("OrderDate", TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [Column("ProveedoresId", TypeName = "int")]
        public int ProveedoresId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("Total", TypeName = "decimal(18,4)")]
        public double Total { get; set; }

        public virtual List<OrderItem> Items { get; set; }
    }
}