﻿namespace FL.Infrastructure.Models.Response
{
    public class CarViewModel
    {
        required public int Id { get; set; }
        required public string Brand { get; set; }
        required public string Model { get; set; }
        required public double Power { get; set; }
        required public double Weight { get; set; }
        required public string Class { get; set; }
    }
}
