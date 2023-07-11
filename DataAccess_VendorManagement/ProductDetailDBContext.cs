using Microsoft.EntityFrameworkCore;
using Model_VendorManagement;

namespace DataAccess_VendorManagement
{
    public class ProductDetailDBContext : DbContext
    {
        public ProductDetailDBContext(DbContextOptions options): base(options){ }

        public DbSet<ProductDetail>  ProductDetails { get; set; }
    }
}