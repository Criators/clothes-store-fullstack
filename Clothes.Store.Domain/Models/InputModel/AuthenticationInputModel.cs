using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Domain.Models.InputModel
{
    public class AuthenticationInputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
