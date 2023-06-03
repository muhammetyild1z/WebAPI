using Microsoft.EntityFrameworkCore;
using System;

namespace WebAPI.Data
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options):base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("deciaml(18,2");
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product(){Id=1,Name="Bilgisayar", CreateDate=DateTime.Now.AddDays(-3),Price=13000,Stock=555},
                new Product(){Id=2,Name="Telefon", CreateDate=DateTime.Now.AddDays(-5),Price=9000,Stock=444}
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
