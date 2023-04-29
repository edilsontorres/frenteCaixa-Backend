using FluentValidation;
using projetoCaixa.Models;

namespace projetoCaixa.Service.Validate
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.UserName).NotNull().NotEmpty().MaximumLength(155);
            RuleFor(x => x.PasswordHash).NotNull().NotEmpty();
        }
    }
}
