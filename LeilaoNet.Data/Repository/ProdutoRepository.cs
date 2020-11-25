using LeilaoNet.Data.Contexts;
using LeilaoNet.Data.Repositories;
using LeilaoNet.Domain.Interfaces.Data;
using LeilaoNet.Domain.Models;

namespace LeilaoNet.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
