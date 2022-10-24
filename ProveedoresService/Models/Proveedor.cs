using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProveedoresService.Models
{
    [Table("Proveedores")]
    public class Proveedor
    {
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column("Type", TypeName = "varchar(100)")]
        public string Type { get; set; }

        [Required]
        [Column("City", TypeName = "varchar(100)")]
        public string City { get; set; }
    }
}
