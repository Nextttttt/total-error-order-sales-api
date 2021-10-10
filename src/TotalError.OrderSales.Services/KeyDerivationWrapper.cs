using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using TotalError.OrderSales.Domain.Abstractions.Helpers;
using TotalError.OrderSales.Domain.Constants;

namespace TotalError.OrderSales.Services
{
    public class KeyDerivationWrapper : IKeyDerivationWrapper
    {
        public byte[] GeneratePdkdf2(string password, byte[] salt, KeyDerivationPrf prf, int iterationCount, int numBytesRequested)
        {
            return KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: NumberConstants.IterationCount,
                numBytesRequested: NumberConstants.KeySize);
        }
    }
}
