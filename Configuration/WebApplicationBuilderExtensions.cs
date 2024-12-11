using Microsoft.EntityFrameworkCore;
using NSE.API.Catalogo.Data;
using NSE.API.Catalogo.Data.Repository;
using NSE.API.Catalogo.Models;
using Microsoft.OpenApi.Models;

namespace NSE.API.Catalogo.Configuration
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddApiConfiguration(this WebApplicationBuilder builder) 
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<CatalogoContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

            });

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
      
            return builder;
        }

        public static WebApplicationBuilder AddDependencyInjection(this WebApplicationBuilder builder) 
        {
            builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddScoped<CatalogoContext>();

            return builder;
        }

        public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "NerdStore Enterprise Catálogo API",
                    Description = "Esta API irá retornar os produtos cadastrados no e-commerce NerdStore Enterprise",
                    Contact = new OpenApiContact() { Name = "Vinícius Souza", Email = "viniciusouza.dev@gmail.com"},
                    License = new OpenApiLicense() { Name = "MIT"}
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

            return builder;
        }
    }
}
