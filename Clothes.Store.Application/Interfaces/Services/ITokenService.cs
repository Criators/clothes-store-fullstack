using Clothes.Store.Application.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Application.Interfaces.Services
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(AuthenticationInputModel input);
    }
}
