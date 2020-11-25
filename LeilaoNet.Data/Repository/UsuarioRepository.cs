using LeilaoNet.Data.Contexts;
using LeilaoNet.Data.Repositories;
using LeilaoNet.Domain.Interfaces.Data;
using LeilaoNet.Domain.Models;

namespace LeilaoNet.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
