using System.ComponentModel.DataAnnotations;

namespace FL.Data.Entities
{
    public class Car : BaseEntity
    {
        [Required]
        required public string Brand { get; set; }
        [Required]
        required public string Model { get; set; }
        [Required]
        required public double Power { get; set; }
        [Required]
        required public double Weight { get; set; }
        [Required]
        required public string Class { get; set; }
    }
}
