using Microsoft.EntityFrameworkCore;
using OrderService.Application.Ports;
using OrderService.Application.UseCases;
using OrderService.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

// EF
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default"),
        sql => sql.EnableRetryOnFailure()
    )
);

// UseCases
builder.Services.AddScoped<CreateOrderUseCase>();
builder.Services.AddScoped<GetOrderByIdUseCase>();

// Ports → Adapters
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

// 👇 aplicar migraciones automáticamente
app.Services.ApplyMigrations();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
