using LeilaoNet.Data.Contexts;
using LeilaoNet.Domain.Interfaces.Data;
using LeilaoNet.Domain.Models;

namespace LeilaoNet.Data.Repositories
{
    public class LeilaoRepository : Repository<Leilao>, ILeilaoRepository
    {
        public LeilaoRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
}