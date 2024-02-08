using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Application.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(bool IsActivate);
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
    }
}
