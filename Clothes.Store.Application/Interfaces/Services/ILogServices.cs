using Clothes.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Application.Interfaces.Services
{
    public interface ILogServices
    {
        Task SaveLog(Log log);
    }
}
