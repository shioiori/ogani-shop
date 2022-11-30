using Microsoft.EntityFrameworkCore;

namespace AppManager.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet<CategoryEntity> CategoryEntities { get; set; }
        public DbSet<FileManageEntity> FileManageEntities { get; set; }
        public DbSet<ProductImageEntity> ProductImageEntities { get; set; }
        public DbSet<ManagerEntity> ManagerEntities { get; set; }
        public DbSet<BannerEntity> BannerEntities { get; set; }
        public DbSet<ShopOrderEntity> ShopOrderEntities { get; set; }
        public DbSet<OrderDetailEntity> OrderDetailEntities { get; set; }
        public DbSet<DiscountEntity> DiscountEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetailEntity>().HasKey(l => new { l.ShopOrderId, l.ProductId });
        }
    }
}
