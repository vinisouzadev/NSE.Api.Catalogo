using Microsoft.EntityFrameworkCore;
using NSE.API.Catalogo.Data;
using System.Net.NetworkInformation;

namespace NSE.API.Catalogo.Configuration
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder) 
        {
            builder.Services.AddDbContext<CatalogoContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("Total", builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
                });
            });

            return builder;
        }
    }
}
