using LeilaoNet.Domain.Core.Messaging;

namespace LeilaoNet.Application.Clients.Commands
{
    public class UsuarioCreateCommand : Command
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}