using TotalError.OrderSales.Domain.Abstractions.Helpers;
using TotalError.OrderSales.Domain.Constants;
using System.Security.Cryptography; 

namespace TotalError.OrderSales.Services
{
    public class SaltGenerator : ISaltGenerator
    {
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[NumberConstants.SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}
