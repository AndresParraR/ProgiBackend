using API.Requests;
using API.Results;
using Application.Services.VehiclesTypes;
using Application.Services.VehicleTotals;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTotalController : ControllerBase
    {
        private readonly IVehicleTotalService _vehicleTotalService;
        private readonly IMapper _mapper;

        public VehicleTotalController(IVehicleTotalService vehicleTotalService, IMapper mapper)
        {
            _vehicleTotalService = vehicleTotalService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<List<VehicleTotalDto>>))]
        public async Task<IActionResult> Get()
        {
            var obj = await _vehicleTotalService.GetAll();
            var result = new GenericResult<List<VehicleTotalDto>>
            {
                Success = true,
                Response = obj
            };
            return Ok(result);
        }

        //// GET api/<VehicleTotalController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<VehicleTotalController>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<VehicleTotalDto>))]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request)
        {
            if (ModelState.IsValid)
            {
                var vehicleTotal = _mapper.Map<VehicleTotal>(request);
                var obj = await _vehicleTotalService.Create(vehicleTotal);
                var result = new GenericResult<VehicleTotalDto>
                {
                    Success = true,
                    Response = obj
                };
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{vehicleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<VehicleTotalDto>))]
        public async Task<IActionResult> EditVehicle(int vehicleId, [FromBody] CreateVehicleRequest request)
        {
            if (ModelState.IsValid)
            {
                var vehicleTotal = _mapper.Map<VehicleTotal>(request);
                var obj = await _vehicleTotalService.Update(vehicleId, vehicleTotal);
                var result = new GenericResult<VehicleTotalDto>
                {
                    Success = true,
                    Response = obj
                };
                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{vehicleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteVehicle(int vehicleId)
        {
            if (ModelState.IsValid)
            {
                var result = await _vehicleTotalService.Delete(vehicleId);
                return Ok(result);
            }

            return BadRequest(ModelState);
        }
    }
}
