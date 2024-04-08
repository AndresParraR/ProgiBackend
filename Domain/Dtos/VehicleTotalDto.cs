using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class VehicleTotalDto
    {
        public int id { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public float BasicFee { get; set; }
        public float SpecialFee { get; set; }
        public float AssociationFee { get; set; }
        public float StorageFee { get; set; }
        public float VehiclePrice { get; set; }
        public float Total { get; set; }
    }
}
