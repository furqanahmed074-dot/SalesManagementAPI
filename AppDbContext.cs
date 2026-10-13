using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders {get; set;}
    public DbSet<Customer> Customers {get; set;}
    public DbSet<Product> Products {get; set;}
    public DbSet<OrderItem> OrderItems{get; set;}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<Order>()
    .HasOne(o => o.Customer)
    .WithMany(c => c.Orders)
    .HasForeignKey(o => o.CustomerId)
    .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Product>().ToTable("Products");
        modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
    }
}