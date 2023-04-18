using Microsoft.EntityFrameworkCore;

namespace LabaWork.Models;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    
    public ProductContext (DbContextOptions<ProductContext> options) : base(options){}
}