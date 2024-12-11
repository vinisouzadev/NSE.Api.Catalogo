using NSE.API.Catalogo.Configuration;
using NSE.WebApi.Core.Identidade;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiConfiguration();
builder.AddJwtConfiguration();
builder.AddDependencyInjection();

builder.Services.AddEndpointsApiExplorer();
builder.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("Total");

app.UseAuthConfiguration();

app.MapControllers();

app.Run();
 