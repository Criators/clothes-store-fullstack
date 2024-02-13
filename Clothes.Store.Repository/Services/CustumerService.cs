using Clothes.Store.Application.Interfaces;
using Clothes.Store.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Repository.Services
{
    public class CustumerService : ICustumerService
    {
        private readonly ICustumer _iCustumer;

        public CustumerService(ICustumer iCustumer)
        {
            _iCustumer = iCustumer;
        }
    }
}
