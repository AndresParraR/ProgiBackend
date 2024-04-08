using API.Results;
using Application.Services.VehiclesTypes;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<List<VehicleType>>))]
        public async Task<IActionResult> Get()
        {
            var obj = await _vehicleTypeService.GetAll();
            var result = new GenericResult<List<VehicleType>>
            {
                Success = true,
                Response = obj
            };
            return Ok(result);
        }
    }
}
