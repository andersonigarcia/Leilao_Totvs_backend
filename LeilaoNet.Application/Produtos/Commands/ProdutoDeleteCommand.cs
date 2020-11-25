using LeilaoNet.Domain.Core.Messaging;
using System;

namespace LeilaoNet.Application.Produtos.Commands
{
    public class ProdutoDeleteCommand : Command
    {
        public ProdutoDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
