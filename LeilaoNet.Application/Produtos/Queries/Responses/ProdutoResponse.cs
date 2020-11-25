using LeilaoNet.Application.Leiloes.Queries.Responses;
using System;

namespace LeilaoNet.Application.Produtos.Queries.Responses
{
    public class ProdutoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Usado { get; set; }
        public decimal Valor { get; set; }
        public LeilaoResponse Leilao { get; set; }
    }
}
