using Clothes.Store.Application.Interfaces;
using Clothes.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly DatabaseContext _context;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(bool IsActivate)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
