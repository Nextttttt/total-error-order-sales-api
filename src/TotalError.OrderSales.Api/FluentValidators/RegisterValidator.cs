using FluentValidation;
using TotalError.OrderSales.Api.Models;

namespace TotalError.OrderSales.Api.FluentValidators
{
    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        public RegisterValidator()
        {
            RuleFor(u => u.Name).NotNull().Length(2,20);
            RuleFor(u => u.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Password must be at least 8 characters with one capital and one lowercase letter, number and a special symbol")
                .MinimumLength(8);

        }
    }
}
