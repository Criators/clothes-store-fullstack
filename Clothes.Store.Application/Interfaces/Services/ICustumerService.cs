﻿using Clothes.Store.Domain.Entities;
using Clothes.Store.Application.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Application.Interfaces.Services
{
    public interface ICustumerService
    {
        Task<Custumer> SaveCustumer(Custumer input);
    }
}
