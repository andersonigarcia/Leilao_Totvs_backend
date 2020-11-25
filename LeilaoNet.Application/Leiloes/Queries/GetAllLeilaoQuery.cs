using System.Collections.Generic;
using LeilaoNet.Application.Leiloes.Queries.Responses;
using LeilaoNet.Domain.Core.Messaging;

namespace LeilaoNet.Application.Leiloes.Queries
{
    public class GetAllLeilaoQuery : Command<IEnumerable<GetAllLeiloesResponse>>
    {
    }
}