using Microsoft.EntityFrameworkCore;
using Model_VendorManagement;
using System.Drawing;

namespace DataAccess_VendorManagement
{
    public class DbContextAccess : DbContext
    {
        public DbContextAccess(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<VendorDetails> VendorDetails { get; set; }

        public DbSet<ProductDetail> ProductDetails { get; set; }

    }
}
