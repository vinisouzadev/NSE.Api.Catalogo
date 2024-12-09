using Microsoft.EntityFrameworkCore;
using NSE.API.Catalogo.Models;

namespace NSE.API.Catalogo.Data
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
