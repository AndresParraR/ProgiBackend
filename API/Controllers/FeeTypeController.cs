using API.Results;
using Application.Services.FeeTypes;
using Application.Services.VehiclesTypes;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeeTypeController : ControllerBase
    {
        private readonly IFeeTypeService _feeTypeService;

        public FeeTypeController(IFeeTypeService feeTypeService)
        {
            _feeTypeService = feeTypeService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<List<FeeType>>))]
        public async Task<IActionResult> Get()
        {
            var obj = await _feeTypeService.GetAll();
            var result = new GenericResult<List<FeeType>>
            {
                Success = true,
                Response = obj
            };
            return Ok(result);
        }
    }
}
