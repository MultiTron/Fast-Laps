using FL.AppServices.Interfaces;
using FL.Infrastructure.Messaging.Request;
using FL.Infrastructure.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FL.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing Cars
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CarsController : ControllerBase
    {
        private readonly ICarManagementService _management;
        /// <summary>
        /// Cars controller constructor
        /// </summary>
        /// <param name="management">Dependancy injection object</param>
        public CarsController(ICarManagementService management)
        {
            _management = management;
        }
        /// <summary>
        /// Get method for Drivers
        /// </summary>
        /// <returns>List of all Drivers</returns>
        [HttpGet("All")]
        public IActionResult Get()
        {
            return Ok(_management.GetCars());
        }
        /// <summary>
        /// Get method for Cars
        /// </summary>
        /// <param name="id">the identifier of the Car</param>
        /// <returns>A Car object</returns>
        [HttpGet("Find/{id}")]
        public IActionResult Find([FromRoute] int id)
        {
            return Ok(_management.GetCar(id));
        }
        /// <summary>
        /// Get method for Cars
        /// </summary>
        /// <param name="currentPage">Current page</param>
        /// <param name="elementsPerPage">Number of elements per page</param>
        /// <returns>List of all Cars with paging</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] int currentPage, int elementsPerPage)
        {
            return Ok(_management.GetCars(new(currentPage, elementsPerPage)));
        }
        /// <summary>
        /// Create method for Cars
        /// </summary>
        /// <param name="car">The car object to be inserted</param>
        /// <returns>Http status code</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Car
        ///     {        
        ///       "brand": "Volkswagen",
        ///       "model": "Golf",
        ///       "power": 110, 
        ///       "weight": 1200,
        ///       "class": "Stock" 
        ///     }
        /// </remarks>
        [HttpPost]
        public IActionResult Create([FromBody] CarModel car)
        {
            return Ok(_management.CreateCar(new CreateCarRequest(car)));
        }
        /// <summary>
        /// Update method for Cars
        /// </summary>
        /// <param name="id">The identifier of the element to be updated</param>
        /// <param name="car">The update values</param>
        /// <returns>Http status code</returns>
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CarModel car)
        {
            return Ok(_management.UpdateCar(new UpdateCarRequest(id, car)));
        }
        /// <summary>
        /// Delete method for Cars
        /// </summary>
        /// <param name="id">The identifier of the element to be removed</param>
        /// <returns>Http status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_management.DeleteCar(new DeleteCarRequest(id)));
        }
    }
}
