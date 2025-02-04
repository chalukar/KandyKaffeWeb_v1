
using KandyKaffe.Service.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KandyKaffe.Services.Catelog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

    }
}
