using Microsoft.EntityFrameworkCore;
using ShirtCatalog.Application;
using ShirtCatalog.Application.Services.Implementations;
using ShirtCatalog.Application.Services.Interfaces;
using ShirtCatalog.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("ShirtCatalogDev");
builder.Services.AddDbContext<ShirtCatalogDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.ConfigureApplicationServices();

builder.Services.AddScoped<IShirtService, ShirtService>();
builder.Services.AddScoped<IVariationService, VariationService>();

var app = builder.Build();

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
