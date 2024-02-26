using Clothes.Store.Application.Interfaces;
using Clothes.Store.Application.Interfaces.Services;
using Clothes.Store.Domain.Entities;
using Clothes.Store.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clothes.Store.Application;

namespace Clothes.Store.Repository.Services
{
    public class CustumerService : ICustumerService
    {
        private readonly ICustumer _iCustumer;
        private readonly IMapper _mapper;

        public CustumerService(ICustumer iCustumer, IMapper mapper)
        {
            _iCustumer = iCustumer;
            _mapper = mapper;
        }

        public async Task<Custumer> SaveCustumer(Custumer custumer)
        {
            custumer.Password = Extensions.EncryptPassword(custumer.Password);

            await _iCustumer.Add(custumer);

            return custumer;
        }
    }
}
