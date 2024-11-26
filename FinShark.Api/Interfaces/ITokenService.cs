using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinShark.Api.Models;

namespace FinShark.Api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}