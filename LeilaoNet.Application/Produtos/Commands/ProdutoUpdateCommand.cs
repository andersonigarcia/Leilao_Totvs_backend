using LeilaoNet.Domain.Core.Messaging;
using System;

namespace LeilaoNet.Application.Produtos.Commands
{
    public class ProdutoUpdateCommand : Command
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Usado { get; set; }
        public decimal Valor { get; set; }
        public Guid LeilaoId { get; set; }
    }
}
