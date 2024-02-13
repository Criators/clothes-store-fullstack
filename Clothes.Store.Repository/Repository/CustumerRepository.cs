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
    public class CustumerRepository : GenericRepository<Custumer>, ICustumer
    {
        private readonly DbContextOptions<DatabaseContext> optionsBuilder;

        public CustumerRepository()
        {
            optionsBuilder = new DbContextOptions<DatabaseContext>();
        }
    }
}
