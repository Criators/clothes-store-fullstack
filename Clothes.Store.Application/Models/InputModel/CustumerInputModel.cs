using Clothes.Store.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Application.Models.InputModel
{
    public class CustumerInputModel
    {
        public string CustumerName { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public UserType? UserType { get; set; }
    }
}
