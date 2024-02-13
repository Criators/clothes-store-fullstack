using AutoMapper;
using Clothes.Store.Domain.Entities;
using Clothes.Store.Domain.Models.InputModel;
using Clothes.Store.Domain.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Domain.Models
{
    public class CustumerProfile : Profile
    {
        public CustumerProfile()
        {
            CreateMap<Custumer, CustumerViewModel>();

            CreateMap<CustumerInputModel, Custumer>();

            CreateMap<AuthenticationInputModel, Custumer>();
        }
    }
}
