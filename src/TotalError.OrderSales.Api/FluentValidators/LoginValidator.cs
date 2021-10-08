using FluentValidation;
using TotalError.OrderSales.Api.Models;

namespace TotalError.OrderSales.Api.FluentValidators
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email).EmailAddress().NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8);
        }
    }
}
