using Application.Common;
using Application.IRepositories;
using Domain.Dtos;
using Domain.Entities;
using Domain.Enumerators;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.VehicleTotals
{
    public class VehicleTotalService : IVehicleTotalService
    {
        private readonly IVehicleTotalRepository _vehicleTotalRepository;

        public VehicleTotalService(IVehicleTotalRepository vehicleTotalRepository)
        {
            _vehicleTotalRepository = vehicleTotalRepository;
        }

        public async Task<List<VehicleTotalDto>> GetAll()
        {
            var vehiclesTotals = await _vehicleTotalRepository.GetAll();

            var vehiclesTotalsDtos = new List<VehicleTotalDto>();

            vehiclesTotals.ForEach(el =>
            {
                FeesCalculator.CalculateNormalFees(el.VehiclePrice, el.VehicleTypeId, out float baseFee, out float specialFee, out float associationFee, out float fixedStorageFee);

                var vehicleType = (VehicleTypeEnum)el.VehicleTypeId;

                vehiclesTotalsDtos.Add(new VehicleTotalDto()
                {
                    id = el.id,
                    VehiclePrice = el.VehiclePrice,
                    VehicleTypeId = el.VehicleTypeId,
                    VehicleTypeName = vehicleType.ToString(),
                    BasicFee = baseFee,
                    SpecialFee = specialFee,
                    AssociationFee = associationFee,
                    StorageFee = fixedStorageFee,
                    Total = el.Total
                });
            });

            return vehiclesTotalsDtos;
        }

        public async Task<VehicleTotalDto> Create(VehicleTotal obj)
        {
            FeesCalculator.CalculateNormalFees(obj.VehiclePrice, obj.VehicleTypeId, out float baseFee, out float specialFee, out float associationFee, out float fixedStorageFee);

            obj.Total = obj.VehiclePrice + baseFee + specialFee + associationFee + fixedStorageFee;

            obj = await _vehicleTotalRepository.Create(obj);

            var vehicleType = (VehicleTypeEnum)obj.VehicleTypeId;
            VehicleTotalDto vehicleTotalDto = new VehicleTotalDto()
            {
                id = obj.id,
                VehiclePrice = obj.VehiclePrice,
                VehicleTypeId = obj.VehicleTypeId,
                VehicleTypeName = vehicleType.ToString(),
                BasicFee = baseFee,
                SpecialFee = specialFee,
                AssociationFee = associationFee,
                StorageFee = fixedStorageFee,
                Total = obj.Total
            };

            return vehicleTotalDto;
        }

        public async Task<VehicleTotalDto> Update(int id, VehicleTotal obj)
        {
            var currentVehicle = await _vehicleTotalRepository.Get(id);
            if (currentVehicle == null)
            {
                throw new NotFoundException("User not found");
            }

            currentVehicle.VehiclePrice = obj.VehiclePrice;
            currentVehicle.VehicleTypeId = obj.VehicleTypeId;

            FeesCalculator.CalculateNormalFees(obj.VehiclePrice, obj.VehicleTypeId, out float baseFee, out float specialFee, out float associationFee, out float fixedStorageFee);

            currentVehicle.Total = obj.VehiclePrice + baseFee + specialFee + associationFee + fixedStorageFee;

            var updatedVehicle = await _vehicleTotalRepository.Update(currentVehicle);

            var vehicleType = (VehicleTypeEnum)obj.VehicleTypeId;

            VehicleTotalDto vehicleTotalDto = new VehicleTotalDto()
            {
                id = updatedVehicle.id,
                VehiclePrice = updatedVehicle.VehiclePrice,
                VehicleTypeId = updatedVehicle.VehicleTypeId,
                VehicleTypeName = vehicleType.ToString(),
                BasicFee = baseFee,
                SpecialFee = specialFee,
                AssociationFee = associationFee,
                StorageFee = fixedStorageFee,
                Total = updatedVehicle.Total
            };

            return vehicleTotalDto;
        }

        public Task<bool> Delete(int id)
        {
            return _vehicleTotalRepository.Delete(id);
        }
    }
}
