using API.Controllers;
using API.Requests;
using API.Results;
using Application.IRepositories;
using Application.Services.VehicleTotals;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Repositories;

namespace UnitTesting.Controller
{
    public class VehicleTotalControllerTest
    {
        private readonly IVehicleTotalService _vehicleTotalService;
        private readonly IMapper _mapper;

        public VehicleTotalControllerTest()
        {
            _vehicleTotalService = A.Fake<IVehicleTotalService>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void VehicleTotalController_Get_ReturnOk()
        {
            //Arrange
            var vehicleTotalList = A.Fake<List<VehicleTotalDto>>();

            var controller = new VehicleTotalController(_vehicleTotalService, _mapper);

            //Act
            var result = controller.Get();

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void VehicleTotalController_Create_ReturnOk()
        {
            //Arrange

            var vehicleRequest = A.Fake<CreateVehicleRequest>();
            var vehicleTotal = A.Fake<VehicleTotal>();
            var vehicleTotalMap = A.Fake<VehicleTotal>();
            var vehicleTotalDto = A.Fake<VehicleTotalDto>();
            A.CallTo(() => _mapper.Map<VehicleTotal>(vehicleRequest)).Returns(vehicleTotal);
            A.CallTo(() => _vehicleTotalService.Create(vehicleTotalMap)).Returns(vehicleTotalDto);
            var controller = new VehicleTotalController(_vehicleTotalService, _mapper);

            //Act
            var result = controller.Create(vehicleRequest);

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void VehicleTotalController_Update_ReturnOk()
        {
            //Arrange

            var vehicleRequest = A.Fake<CreateVehicleRequest>();
            int vehicleId = 1;
            var vehicleTotal = A.Fake<VehicleTotal>();
            var vehicleTotalMap = A.Fake<VehicleTotal>();
            var vehicleTotalDto = A.Fake<VehicleTotalDto>();
            A.CallTo(() => _mapper.Map<VehicleTotal>(vehicleRequest)).Returns(vehicleTotal);
            A.CallTo(() => _vehicleTotalService.Update(vehicleId, vehicleTotalMap)).Returns(vehicleTotalDto);
            var controller = new VehicleTotalController(_vehicleTotalService, _mapper);

            //Act
            var result = controller.EditVehicle(vehicleId, vehicleRequest);

            //Assert
            result.Should().NotBeNull();
        }


        [Fact]
        public void VehicleTotalController_Delete_ReturnOk()
        {
            //Arrange

            int vehicleId = 1;
            A.CallTo(() => _vehicleTotalService.Delete(vehicleId)).Returns(true);
            var controller = new VehicleTotalController(_vehicleTotalService, _mapper);

            //Act
            var result = controller.DeleteVehicle(vehicleId);

            //Assert
            result.Should().NotBeNull();
        }
    }
}