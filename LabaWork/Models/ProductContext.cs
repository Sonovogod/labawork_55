using Microsoft.EntityFrameworkCore;

namespace LabaWork.Models;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Brand> Brand { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options) {}
}