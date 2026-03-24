using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Veterinaria.API.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VeterinariaAPIContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Veterinaria_render") ?? throw new InvalidOperationException("Connection string 'VeterinariaAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   

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
