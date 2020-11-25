using FluentValidation;
using FluentValidation.Results;
using LailaoNet.Domain.Core.Data;
using System.Threading.Tasks;

namespace LeilaoNet.Domain.Core.Messaging
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected ValidationResult ValidationResult { get; } = new ValidationResult();

        protected CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected bool IsValid<TParameter>(TParameter target) where TParameter : AbstractValidator<TParameter>
        {
            var validationResult = target.Validate(target);
            foreach (var error in validationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> Commit(string message)
        {
            if (!await _uow.CommitAsync())
                AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit()
        {
            return await Commit("Ocorreu um erro ao salvar os dados!");
        }

        protected bool HasChanges()
        {
            return _uow.HasChanges();
        }
    }
}
