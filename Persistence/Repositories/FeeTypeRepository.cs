using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FeeTypeRepository : IFeeTypeRepository
    {
        private readonly DataContext _dataContext;

        public FeeTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<FeeType> Create(FeeType instance)
        {
            throw new NotImplementedException();
        }

        public Task<FeeType> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FeeType>> GetAll()
        {
            return _dataContext.FeeType.ToListAsync();
        }

        public Task<FeeType> Update(FeeType instance)
        {
            throw new NotImplementedException();
        }
    }
}
