﻿using NSE.Core.Data;

namespace NSE.API.Catalogo.Models
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();

        Task<Produto> ObterPorId(Guid id);

        void Adicionar(Produto produto);

        void Atualizar(Produto produto);
    }
}
