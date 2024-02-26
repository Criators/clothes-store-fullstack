using Clothes.Store.Domain.Entities;
using Clothes.Store.Application.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Application.Interfaces
{
    public interface ICustumer : IGeneric<Custumer>
    {
        Task<Custumer> GetCustumerByEmailAsync(string email);
        Custumer GetCustumerByEmail(string email);
        Custumer GetCustumerByCPF(string cpf);
    }
}
