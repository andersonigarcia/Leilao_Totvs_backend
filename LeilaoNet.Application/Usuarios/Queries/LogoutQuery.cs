using LeilaoNet.Application.Usuarios.Queries.Responses;
using LeilaoNet.Domain.Core.Messaging;

namespace LeilaoNet.Application.Usuarios.Queries
{
    public class LogoutQuery : Command<LogoutResponse>
    {
        public string Username { get; set; }
    }
}
