using Mealthy.Mealthy.Domain.Model;
using Mealthy.Mealthy.Domain.Models;
using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Shared.Persistence.Contexts;

//Provides access to the database
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    
    public DbSet<Product>Products { get; set; }
    
    public DbSet<Store> Stores { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Recipe>().ToTable("Recipes");
        builder.Entity<Recipe>().HasKey(p => p.Id);
        builder.Entity<Recipe>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Recipe>().Property(p => p.Title).IsRequired().HasMaxLength(30);
        builder.Entity<Recipe>().Property(p => p.Description).IsRequired().HasMaxLength(100);
        builder.Entity<Recipe>().Property(p => p.PreparationTime).IsRequired();
        
        //Relationships
        builder.Entity<Recipe>().HasMany(p => p.Ingredients).WithOne(p => p.Recipe).HasForeignKey(p => p.RecipeId);
        builder.Entity<Recipe>().HasMany(p => p.Steps).WithOne(p => p.Recipe).HasForeignKey(p => p.RecipeId);
        
        builder.Entity<Ingredient>().ToTable("Ingredients");
        builder.Entity<Ingredient>().HasKey(p => p.Id);
        builder.Entity<Ingredient>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Ingredient>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Ingredient>().Property(p => p.Quantity).IsRequired();
        
        builder.Entity<Step>().ToTable("Steps");
        builder.Entity<Step>().HasKey(p => p.Id);
        builder.Entity<Step>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Step>().Property(p => p.Description).IsRequired().HasMaxLength(100);
        
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd(); 
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(70); 
        builder.Entity<Product>().Property(p => p.Category).IsRequired().HasMaxLength(70); 
        builder.Entity<Product>().Property(p => p.Price).IsRequired();
        builder.Entity<Product>().Property(p => p.Unit).IsRequired().HasMaxLength(70); 
        builder.Entity<Product>().Property(p => p.Quantity).IsRequired();
        builder.Entity<Product>().Property(p => p.photoUrl).IsRequired().HasMaxLength(200);

        builder.Entity<Store>().ToTable("Stores");
        builder.Entity<Store>().HasKey(s => s.Id);
        builder.Entity<Store>().Property(s=>s.Id).IsRequired().ValueGeneratedOnAdd(); 
        builder.Entity<Store>().Property(s=>s.name).IsRequired().HasMaxLength(70); 
        builder.Entity<Store>().Property(s=>s.description).IsRequired().HasMaxLength(70); 
        builder.Entity<Store>().Property(s=>s.photoUrl).IsRequired();
        builder.Entity<Store>().Ignore(s => s.ProductsId).Property(s => s.ProductsIdString).HasColumnName("ProductsId");


        //Naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}