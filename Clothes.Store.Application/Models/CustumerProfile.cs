using AutoMapper;
using Clothes.Store.Domain.Entities;
using Clothes.Store.Application.Models.InputModel;
using Clothes.Store.Application.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Application.Models
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
