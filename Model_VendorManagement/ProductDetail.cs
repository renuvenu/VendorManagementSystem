using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model_VendorManagement
{
    public class ProductDetail
    {
        [Required]
        public Guid ProductId { get; set; }

        [ForeignKey("VentorDetails")]

        public Guid VendorId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        
        public string? ProductDescription { get; set; }

        [Required]
        public string? Price { get; set;}

        
    }
}