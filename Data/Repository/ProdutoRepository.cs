using Microsoft.EntityFrameworkCore;
using NSE.API.Catalogo.Models;

namespace NSE.API.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
