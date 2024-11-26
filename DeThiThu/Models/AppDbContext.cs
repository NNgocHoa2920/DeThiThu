using Microsoft.EntityFrameworkCore;

namespace DeThiThu.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<DonHang> DonHangs { get; set; } 
        public DbSet<KhachHang> KhachHangs { get; set; } 

    }
}
