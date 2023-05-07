using FluentValidation;
using projetoCaixa.DTOs;
using projetoCaixa.Models;

namespace projetoCaixa.Service.Validate
{
    public class UserValidation : AbstractValidator<UserRequesteDTO>
    {
        public UserValidation()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(155);
            RuleFor(x => x.PasswordHash).NotNull().NotEmpty();
        }
    }
}
