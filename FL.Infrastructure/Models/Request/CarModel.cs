namespace FL.Infrastructure.Models.Request
{
    public class CarModel
    {
        required public string Brand { get; set; }
        required public string Model { get; set; }
        required public double Power { get; set; }
        required public double Weight { get; set; }
        required public string Class { get; set; }
    }
}