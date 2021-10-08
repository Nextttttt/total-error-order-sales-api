using TotalError.OrderSales.Domain.Dtos;

namespace TotalError.OrderSales.Domain.Abstractions.Helpers
{
    public interface IHasherService
    {
        PasswordAndSaltDto HashPassword(string password);
        bool VerifyHashedPassword(string providedPassword, string hashedPassword, string saltString);
    }
}
