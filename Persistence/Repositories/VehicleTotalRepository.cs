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
    public class VehicleTotalRepository : IVehicleTotalRepository
    {
        private readonly DataContext _dataContext;

        public VehicleTotalRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<VehicleTotal> Create(VehicleTotal instance)
        {
            _dataContext.VehicleTotal.Add(instance);
            await _dataContext.SaveChangesAsync();
            return instance;
        }

        public Task<VehicleTotal> Get(int id)
        {
            return _dataContext.VehicleTotal.FirstOrDefaultAsync(u => u.id == id);
        }

        public Task<List<VehicleTotal>> GetAll()
        {
            return _dataContext.VehicleTotal.ToListAsync();
        }

        public async Task<VehicleTotal> Update(VehicleTotal instance)
        {
            _dataContext.Update(instance);
            await _dataContext.SaveChangesAsync();
            return instance;
        }
        public async Task<bool> Delete(int vehicleId)
        {
            await _dataContext.VehicleTotal.Where(u => u.id == vehicleId).ExecuteDeleteAsync();
            return true;
        }
    }
}
