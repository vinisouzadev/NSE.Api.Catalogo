using NSE.API.Catalogo.Models;

namespace NSE.API.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        public void Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
