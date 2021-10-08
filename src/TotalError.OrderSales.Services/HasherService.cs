using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using TotalError.OrderSales.Domain.Abstractions.Helpers;
using TotalError.OrderSales.Domain.Constants;
using TotalError.OrderSales.Domain.Dtos;
using System;
using System.Security.Cryptography;

namespace TotalError.OrderSales.Services
{
    public class HasherService : IHasherService
    {
        private readonly IKeyDerivationWrapper _keyDerivationWrapper;
        private readonly ISaltGenerator _saltGenerator;

        public HasherService(IKeyDerivationWrapper keyDerivationWrapper, ISaltGenerator saltGenerator)
        {
            _keyDerivationWrapper = keyDerivationWrapper;
            _saltGenerator = saltGenerator;
        }

        public PasswordAndSaltDto HashPassword(string password)
        {
            var salt = _saltGenerator.GenerateSalt();
            var hash = _keyDerivationWrapper.GeneratePdkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: NumberConstants.IterationCount,
                numBytesRequested: NumberConstants.KeySize);

            var outputBytes = new byte[NumberConstants.KeySize];
            Buffer.BlockCopy(hash, 0, outputBytes, 0, NumberConstants.KeySize);

            return new PasswordAndSaltDto
            {
                Password = Convert.ToBase64String(outputBytes),
                Salt = Convert.ToBase64String(salt)
            };
        }

        public bool VerifyHashedPassword(string providedPassword, string hashedPassword, string saltString)
        {
            if (hashedPassword == null)
            {
                throw new ArgumentNullException(nameof(hashedPassword));
            }
            if (providedPassword == null)
            {
                throw new ArgumentNullException(nameof(providedPassword));
            }

            byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);
            if (decodedHashedPassword.Length == 0)
            {
                return false;
            }

            return VerifyHashedPassword(decodedHashedPassword, providedPassword, saltString);
        }

        private bool VerifyHashedPassword(byte[] decodedHashedPassword, string providedPassword, string salt)
        {
            byte[] saltByteArray = Convert.FromBase64String(salt);

            var actualHash = _keyDerivationWrapper.GeneratePdkdf2(
                password: providedPassword,
                salt: saltByteArray,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: NumberConstants.IterationCount,
                numBytesRequested: NumberConstants.KeySize);

            return CryptographicOperations.FixedTimeEquals(actualHash, decodedHashedPassword);
        }
    }
}
