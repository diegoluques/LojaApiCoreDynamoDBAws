using FluentValidation;
using FluentValidation.Results;
using SharedApiCore.Domain.Bases;
using SharedApiCore.Domain.Contracts;
using SharedApiCore.Domain.Notifications;

namespace SharedApiCore.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notificador;

        protected BaseService(INotifier notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : EntityBase
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
