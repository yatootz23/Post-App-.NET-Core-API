using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using postapp.Models;

namespace postapp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}