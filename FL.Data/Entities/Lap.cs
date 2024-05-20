using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FL.Data.Entities
{
    public class Lap : BaseEntity
    {
        public TimeSpan? Sector1 { get; set; }
        public TimeSpan? Sector2 { get; set; }
        public TimeSpan? Sector3 { get; set; }
        required public TimeSpan LapTime { get; set; }
        [Required]
        [ForeignKey("Driver")]
        required public int DriverId { get; set; }
        [Required]
        required public virtual Driver Driver { get; set; }
    }
}
