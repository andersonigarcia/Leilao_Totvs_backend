using LeilaoNet.Application.Usuarios.Queries.Responses;
using LeilaoNet.Domain.Core.Messaging;

namespace LeilaoNet.Application.Usuarios.Queries
{
    public class LoginQuery : Command<LoginResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
