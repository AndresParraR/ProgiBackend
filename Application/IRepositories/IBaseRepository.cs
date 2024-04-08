using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IBaseRepository<T>
    {
        Task<T> Get(int id);
        Task<T> Create(T instance);
        Task<T> Update(T instance);
        Task<List<T>> GetAll();
    }
}
