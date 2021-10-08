using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TotalError.OrderSales.Domain.Abstractions.Helpers
{
    public interface IKeyDerivationWrapper
    {
        byte[] GeneratePdkdf2(string password, byte[] salt, KeyDerivationPrf prf, int iterationCount, int numBytesRequested);
    }
}
