using FluentValidation.Results;
using System.Linq;

namespace projetoCaixa.Entites.Validate.Errors
{
    public static class ValidatorErrorExtension
    {
        public static IList<CustomErrorValidator> ToCustomErrorValidator(this IList<ValidationFailure> failures)
        {
            return failures.Select(x => new CustomErrorValidator(x.PropertyName, x.ErrorMessage)).ToList();
        }
    }
}
