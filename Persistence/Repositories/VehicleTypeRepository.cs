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
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private readonly DataContext _dataContext;

        public VehicleTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<VehicleType> Create(VehicleType instance)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleType> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleType>> GetAll()
        {
            return _dataContext.VehicleType.ToListAsync();
        }

        public Task<VehicleType> Update(VehicleType instance)
        {
            throw new NotImplementedException();
        }
    }
}
