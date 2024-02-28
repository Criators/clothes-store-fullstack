using Clothes.Store.Application.Interfaces;
using Clothes.Store.Application.Interfaces.Services;
using Clothes.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Repository.Services
{
    public class LogServices : ILogServices
    {
        private readonly ILog _log;

        public LogServices(ILog log)
        {
            _log = log;
        }

        public async Task SaveLog(Log log)
        {
                await _log.Add(log);
        }
    }
}
