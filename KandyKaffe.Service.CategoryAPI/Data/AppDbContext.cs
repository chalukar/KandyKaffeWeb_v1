
using KandyKaffe.Service.CategoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KandyKaffe.Services.Categoty.Data
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

        public DbSet<Category> Categories { get; set; }

    }
}
