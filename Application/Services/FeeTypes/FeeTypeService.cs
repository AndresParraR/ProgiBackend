using Application.IRepositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.FeeTypes
{
    public class FeeTypeService : IFeeTypeService
    {
        private readonly IFeeTypeRepository _feeTypeRepository;
        public FeeTypeService(IFeeTypeRepository feeTypeRepository)
        {
            _feeTypeRepository = feeTypeRepository;
        }

        public Task<List<FeeType>> GetAll()
        {
            return _feeTypeRepository.GetAll();
        }
    }
}
