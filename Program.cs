using NSE.API.Catalogo.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddApiConfiguration()
    .AddDependencyInjection();
builder.Services.AddEndpointsApiExplorer();
builder.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
 