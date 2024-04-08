using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VehicleTotals
{
    public interface IVehicleTotalService
    {
        public Task<List<VehicleTotalDto>> GetAll();
        public Task<VehicleTotalDto> Create(VehicleTotal obj);
        public Task<VehicleTotalDto> Update(int id, VehicleTotal obj);
        public Task<bool> Delete(int id);
    }
}
