using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VehiclesTypes
{
    public interface IVehicleTypeService
    {
        public Task<List<VehicleType>> GetAll();
    }
}
