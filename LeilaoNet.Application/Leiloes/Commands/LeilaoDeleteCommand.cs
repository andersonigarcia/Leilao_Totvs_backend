using LeilaoNet.Domain.Core.Messaging;
using System;

namespace LeilaoNet.Application.Clients.Commands
{
    public class LeilaoDeleteCommand : Command
    {
        public LeilaoDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}