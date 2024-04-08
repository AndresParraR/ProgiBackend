using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace API.Requests
{
    public class CreateVehicleRequest
    {
        [Required]
        public float VehiclePrice { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }
    }
}
