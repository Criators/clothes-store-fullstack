using Clothes.Store.Application.Interfaces;
using Clothes.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Repository.Repository
{
    public class LogRepository : GenericRepository<Log>, ILog
    {
        public LogRepository(DbContextOptions<DatabaseContext> options) : base(new DatabaseContext(options))
        {
        }
    }
}
