using Mealthy.Mealthy.Domain.Repository;
using Mealthy.Security.Authorization.Handlers.Implementations;
using Mealthy.Security.Authorization.Handlers.Interfaces;
using Mealthy.Security.Authorization.Middleware;
using Mealthy.Security.Authorization.Settings;
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


//Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddCors();
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserservice, UserService>();

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

//configure error handler middleware
app.UseMiddleware<ErrorHandlerMiddleware>();
//configure JWT Handling
app.UseMiddleware<JwtMiddleware>();
//configure CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
    
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