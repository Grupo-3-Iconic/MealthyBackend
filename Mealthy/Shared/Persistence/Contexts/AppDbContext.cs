using Mealthy.Mealthy.Domain.Model;
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
        
        //Naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}