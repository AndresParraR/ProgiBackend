using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.FeeTypes
{
    public interface IFeeTypeService
    {
        public Task<List<FeeType>> GetAll();
    }
}
