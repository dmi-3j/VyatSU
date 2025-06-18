using Microsoft.EntityFrameworkCore;
using ServiceCenter.Classes;

namespace ServiceCenter.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPart> OrderParts { get; set; }
        public DbSet<WarehousePart> WarehouseParts { get; set; }
        public DbSet<Master> Masters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=servicecenter.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<OrderPart>()
                .HasOne(op => op.Order)
                .WithMany(o => o.Parts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<WarehousePart>()
                .HasKey(wp => wp.Id);

            modelBuilder.Entity<Master>()
                .HasKey(m => m.MasterId);
        }
    }
}
