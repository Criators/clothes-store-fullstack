using Clothes.Store.Application.Interfaces;
using Clothes.Store.Domain.Entities;
using Clothes.Store.Application.Validators.Custumer;
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
        public CustumerRepository(DbContextOptions<DatabaseContext> options) : base(new DatabaseContext(options))
        {
        }

        public CustumerRepository(DbContext context) : base(context)
        {
        }

        public Task<Custumer> GetCustumerByEmailAsync(string email)
        {
            return (
                from c in GetContext().Set<Custumer>()
                where c.Email == email
                select c).AsNoTracking().FirstOrDefaultAsync();
        }

        public Custumer GetCustumerByEmail(string email)
        {
            return (
                from c in GetContext().Set<Custumer>()
                where c.Email == email
                select c).AsNoTracking().FirstOrDefault();
        }

        public Custumer GetCustumerByCPF(string cpf)
        {
            return (
                from c in GetContext().Set<Custumer>()
                where c.CPF == cpf
                select c).AsNoTracking().FirstOrDefault();
        }
    }
}
