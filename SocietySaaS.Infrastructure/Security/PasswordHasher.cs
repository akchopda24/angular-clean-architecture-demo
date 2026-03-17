using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SocietySaaS.Application.Common.Interfaces;
using System.Security.Cryptography;

namespace SocietySaaS.Infrastructure.Security
{
   
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password, out string salt)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(128 / 8);
            salt = Convert.ToBase64String(saltBytes);

            var hash = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password,
                    saltBytes,
                    KeyDerivationPrf.HMACSHA256,
                    10000,
                    256 / 8));

            return hash;
        }

        public bool Verify(string password, string hash, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);

            var newHash = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password,
                    saltBytes,
                    KeyDerivationPrf.HMACSHA256,
                    10000,
                    256 / 8));

            return newHash == hash;
        }
    }
}