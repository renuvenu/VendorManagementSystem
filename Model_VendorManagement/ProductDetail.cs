using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model_VendorManagement
{
    public class ProductDetail
    {
        [Required]
        public Guid Id { get; set; }

        [ForeignKey("VentorManagement")]

        public Guid VendorId { get; set; }

        [Required]
        [MaxLength(255)]
        public string? ProductName { get; set; }

        [MaxLength(255)]
        public string? ProductDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(28, 2)")]
        public decimal? Price { get; set;}

        
    }
}