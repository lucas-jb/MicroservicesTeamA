using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductoService.Models
{
    [Table("Productos", Schema = "ProductosSchema")]
    public class Producto
    {
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("Price" ,TypeName = "decimal(18,4)")]
        public double Price { get; set; }
    }
}
