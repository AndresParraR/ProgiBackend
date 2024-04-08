using API.Requests;
using AutoMapper;
using Domain.Entities;

namespace API
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CreateVehicleRequest, VehicleTotal>();
        }
    }
}
