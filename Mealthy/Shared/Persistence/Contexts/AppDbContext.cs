﻿using Mealthy.Mealthy.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Mealthy.Shared.Persistence.Contexts;

//Provides access to the database
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
       
       
        //Naming convention
        builder.UseSnakeCaseNamingConvention();
    }
}