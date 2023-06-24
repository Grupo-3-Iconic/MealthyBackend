using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Security.Domain.Repositories;
using Mealthy.Security.Domain.Services;
using Mealthy.Security.Persistence.Repositories;
using Mealthy.Security.Services;
using Mealthy.Shared.Persistence.Contexts;
using Mealthy.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserservice, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(Mealthy.Mealthy.Mapping.ModelToResourceProfile),
    typeof(Mealthy.Mealthy.Mapping.ResourceToModelProfile),
    typeof(Mealthy.Security.Mapping.ModelToResourceProfile),
    typeof(Mealthy.Security.Mapping.ResourceModelToProfile)
);

var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();