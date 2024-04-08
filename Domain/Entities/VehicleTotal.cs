using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class VehicleTotal
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }
        [Required]
        public float VehiclePrice { get; set; }
        [Required]
        public float Total { get; set; }
    }
}