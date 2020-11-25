using AutoMapper;
using FluentValidation.Results;
using LeilaoNet.Application.Clients.Commands;
using LeilaoNet.Domain.Core.Messaging;
using LeilaoNet.Domain.Interfaces.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LeilaoNet.Application.Clients.Handlers
{
    public class LeilaoUpdateCommandHandler : CommandHandler, IRequestHandler<LeilaoUpdateCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILeilaoRepository _clientRepository;

        public LeilaoUpdateCommandHandler(IMediator mediator, IMapper mapper, ILeilaoRepository clientRepository)
            : base(clientRepository.UnitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(LeilaoUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _clientRepository.GetByIdAsync(request.Id);
            return await Commit();
        }
    }
}