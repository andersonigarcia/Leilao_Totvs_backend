using System;
using LeilaoNet.Application.Leiloes.Queries.Responses;
using LeilaoNet.Domain.Core.Messaging;

namespace LeilaoNet.Application.Leiloes.Queries
{
    public class GetLeilaoByIdQuery : Command<GetLeilaoByIdResponse>
    {
        public GetLeilaoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}