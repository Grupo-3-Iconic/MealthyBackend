using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Shared.Persistence.Contexts;

//Provides access to the database
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Product>Products { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Supply> Supplies { get; set; }
    public DbSet<Market> Markets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Recipe>().ToTable("Recipes");
        builder.Entity<Recipe>().HasKey(p => p.Id);
        builder.Entity<Recipe>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Recipe>().Property(p => p.Title).IsRequired().HasMaxLength(30);
        builder.Entity<Recipe>().Property(p => p.Description).IsRequired().HasMaxLength(100);
        builder.Entity<Recipe>().Property(p => p.PreparationTime).IsRequired();
        builder.Entity<Recipe>().Property(p => p.Servings).IsRequired();
        builder.Entity<Recipe>().Property(p => p.PhotoUrl).IsRequired();
        
        builder.Entity<Supply>().ToTable("Supplies");
        builder.Entity<Supply>().HasKey(p => p.Id);
        builder.Entity<Supply>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Supply>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Supply>().Property(p => p.Unit).IsRequired().HasMaxLength(10);
        builder.Entity<Supply>().Property(p => p.Quantity).IsRequired();
        
        //Relationships
        builder.Entity<Recipe>().HasMany(p => p.Ingredients).WithOne(p => p.Recipe).HasForeignKey(p => p.RecipeId);
        builder.Entity<Recipe>().HasMany(p => p.Steps).WithOne(p => p.Recipe).HasForeignKey(p => p.RecipeId);
        
        builder.Entity<Ingredient>().ToTable("Ingredients");
        builder.Entity<Ingredient>().HasKey(p => p.Id);
        builder.Entity<Ingredient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Ingredient>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Ingredient>().Property(p => p.Unit).IsRequired().HasMaxLength(10);
        builder.Entity<Ingredient>().Property(p => p.Quantity).IsRequired();
        
        builder.Entity<Step>().ToTable("Steps");
        builder.Entity<Step>().HasKey(p => p.Id);
        builder.Entity<Step>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Step>().Property(p => p.Description).IsRequired().HasMaxLength(100);
        
        //Products
        base.OnModelCreating(builder);
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd(); 
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(70); 
        builder.Entity<Product>().Property(p => p.Category).IsRequired().HasMaxLength(70); 
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.Unit).IsRequired().HasMaxLength(70); 
        builder.Entity<Product>().Property(p => p.Quantity).IsRequired();
        builder.Entity<Product>().Property(p => p.storeId).IsRequired();
        builder.Entity<Product>().Property(p => p.photoUrl).IsRequired().HasMaxLength(200); 
        
        
        builder.Entity<Market>().ToTable("Markets");
        builder.Entity<Market>().HasKey(p => p.Id);
        builder.Entity<Market>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Market>().Property(p => p.storeName).IsRequired().HasMaxLength(50);
        builder.Entity<Market>().Property(p => p.description).IsRequired().HasMaxLength(200);
        builder.Entity<Market>().Property(p => p.photo).IsRequired().HasMaxLength(600);
        
        //Naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}
