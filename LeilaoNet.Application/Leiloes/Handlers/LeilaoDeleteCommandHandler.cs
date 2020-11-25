using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using LeilaoNet.Application.Clients.Commands;
using LeilaoNet.Domain.Core.Messaging;
using LeilaoNet.Domain.Interfaces.Data;

namespace LeilaoNet.Application.Clients.Handlers
{
    public class LeilaoDeleteCommandHandler : CommandHandler, IRequestHandler<LeilaoDeleteCommand, ValidationResult>
    {
        private readonly IMediator _mediator;
        private readonly ILeilaoRepository _clienteRepository;

        public LeilaoDeleteCommandHandler(IMediator mediator, ILeilaoRepository clientRepository)
            : base(clientRepository.UnitOfWork)
        {
            _mediator = mediator;
            _clienteRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(LeilaoDeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _clienteRepository.GetByIdAsync(request.Id);
            await _clienteRepository.DeleteAsync(entity);
            return await Commit();
        }
    }
}