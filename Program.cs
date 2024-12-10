using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using NSE.API.Catalogo.Configuration;
using NSE.API.Catalogo.Data;
using NSE.API.Catalogo.Data.Repository;
using NSE.API.Catalogo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .AddApiConfiguration()
    .AddDependencyInjection();


builder.Services.AddEndpointsApiExplorer();

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
 