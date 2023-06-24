using Mealthy.Mealthy.Domain.Models;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Shared.Persistence.Contexts;

//Provides access to the database
public class AppDbContext : DbContext
{
    public DbSet<Product>Products { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd(); 
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(70); 
        builder.Entity<Product>().Property(p => p.Category).IsRequired().HasMaxLength(70); 
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.Unit).IsRequired().HasMaxLength(70); 
        builder.Entity<Product>().Property(p => p.Quantity).IsRequired();
        builder.Entity<Product>().Property(p => p.photoUrl).IsRequired().HasMaxLength(200); 
        

       
        //Naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}