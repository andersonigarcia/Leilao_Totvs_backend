using AutoMapper;
using FluentValidation.Results;
using LeilaoNet.Application.Clients.Commands;
using LeilaoNet.Domain.Core.Messaging;
using LeilaoNet.Domain.Interfaces.Data;
using LeilaoNet.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LeilaoNet.Application.Clients.Handlers
{
    public class LeilaoCreateCommandHandler : CommandHandler, IRequestHandler<LeilaoCreateCommand, ValidationResult>
    {
        private readonly IMapper _mapper;
        private readonly ILeilaoRepository _leilaoRepository;

        public LeilaoCreateCommandHandler(IMapper mapper, ILeilaoRepository clientRepository)
            : base(clientRepository.UnitOfWork)
        {
            _mapper = mapper;
            _leilaoRepository = clientRepository;
        }

        public async Task<ValidationResult> Handle(LeilaoCreateCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Leilao>(request);

            if (!entity.IsValid())
                return entity.ValidationResult;

            await _leilaoRepository.CreateAsync(entity);

            return await Commit();
        }
    }
}