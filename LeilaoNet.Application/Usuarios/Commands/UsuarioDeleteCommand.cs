using LeilaoNet.Domain.Core.Messaging;
using System;

namespace LeilaoNet.Application.Clients.Commands
{
    public class UsuarioDeleteCommand : Command
    {
        public UsuarioDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}