using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FL.Data.Entities
{
    public class Driver : BaseEntity
    {
        [Required]
        required public string FirstName { get; set; }
        [Required]
        required public string LastName { get; set; }
        [Required]
        [ForeignKey("Car")]
        required public int CarId { get; set; }
        [Required]
        required public virtual Car Car { get; set; }
        public virtual ICollection<Lap>? Laps { get; set; }
    }
}
