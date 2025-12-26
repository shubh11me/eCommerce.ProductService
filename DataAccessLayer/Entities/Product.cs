using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        [Key]
        [Column("ProductID", TypeName = "char(36)")]
        public Guid ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; } = null!;

        [StringLength(50)]
        public string? Category { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? UnitPrice { get; set; }

        public int? QuantityInStock { get; set; }
    }
}
