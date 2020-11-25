using AutoMapper;
using LeilaoNet.Application.Leiloes.Queries;
using LeilaoNet.Application.Leiloes.Queries.Responses;
using LeilaoNet.Domain.Core.Messaging;
using LeilaoNet.Domain.Interfaces.Data;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LeilaoNet.Application.Clients.Handlers
{
    public class GetAllLeiloesQueryHandler : CommandHandler, IRequestHandler<GetAllLeilaoQuery, IEnumerable<GetAllLeiloesResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ILeilaoRepository _clientRepository;

        public GetAllLeiloesQueryHandler(IMapper mapper, ILeilaoRepository clientRepository)
            : base(clientRepository.UnitOfWork)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        public async Task<IEnumerable<GetAllLeiloesResponse>> Handle(GetAllLeilaoQuery request, CancellationToken cancellationToken)
        {
            var entities = await _clientRepository.GetAsync();
            return _mapper.Map<IEnumerable<GetAllLeiloesResponse>>(entities);
        }
    }
}
