using FluentValidation;
using FluentValidation.Results;
using Pet.Business.Core.Models;
using Pet.Business.Core.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Business.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult) //usar do FluentValidation.Results;
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }
        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }


        //na assinatura do metodo generico vamos reecber um TV *validacao e um TE * entidade,
        //onde o TV tem que ser um classe ou herdar de abstractValidator da entidade que estamos passando como generica, onde esta entidade tem eu ser herdeira de Entity 
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;

        }


    }
}
