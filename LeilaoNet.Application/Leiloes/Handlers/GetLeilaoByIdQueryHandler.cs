using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using LeilaoNet.Application.Leiloes.Queries;
using LeilaoNet.Application.Leiloes.Queries.Responses;
using LeilaoNet.Domain.Core.Messaging;
using LeilaoNet.Domain.Interfaces.Data;

namespace LeilaoNet.Application.Clients.Handlers
{
    public class GetLeilaoByIdQueryHandler : CommandHandler, IRequestHandler<GetLeilaoByIdQuery, GetLeilaoByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeilaoRepository _clientRepository;

        public GetLeilaoByIdQueryHandler(IMapper mapper, ILeilaoRepository clientRepository)
            : base(clientRepository.UnitOfWork)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<GetLeilaoByIdResponse> Handle(GetLeilaoByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _clientRepository.GetByIdAsync(request.Id);
            return _mapper.Map<GetLeilaoByIdResponse>(entity);
        }
    }
}