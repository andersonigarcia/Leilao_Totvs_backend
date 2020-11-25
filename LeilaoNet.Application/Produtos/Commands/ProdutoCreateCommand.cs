using LeilaoNet.Domain.Core.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeilaoNet.Application.Produtos.Commands
{
    public class ProdutoCreateCommand : Command
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Usado { get; set; }
        public decimal Valor { get; set; }
        public Guid LeilaoId { get; set; }
    }
}
