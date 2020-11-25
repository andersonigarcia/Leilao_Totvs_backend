using LeilaoNet.Domain.Core.Messaging;

namespace LeilaoNet.Application.Clients.Commands
{
    public class UsuarioUpdateCommand : Command
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}