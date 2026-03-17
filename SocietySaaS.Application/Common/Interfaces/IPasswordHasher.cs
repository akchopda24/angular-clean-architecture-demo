using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocietySaaS.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password, out string salt);

        bool Verify(string password, string hash, string salt);
    }
}