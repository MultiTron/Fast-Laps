using FL.AppServices.Interfaces;
using FL.AppServices.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FL.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing Drivers 
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverManagementService _management;
        /// <summary>
        /// Drivers controller constructor
        /// </summary>
        /// <param name="management">Dependancy injection object</param>
        public DriversController(IDriverManagementService management)
        {
            _management = management;
        }
        /// <summary>
        /// Get method for Drivers
        /// </summary>
        /// <param name="currentPage">Current page</param>
        /// <param name="elementsPerPage">Number of elements per page</param>
        /// <returns>List of all Drivers with paging</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] int currentPage, int elementsPerPage)
        {
            return Ok(_management.GetDrivers(new(currentPage, elementsPerPage)));
        }
        /// <summary>
        /// Create method for Drivers
        /// </summary>
        /// <param name="driver">The driver object to be inserted</param>
        /// <returns>Http status code</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Driver
        ///     {        
        ///       "firstName": "Mike",
        ///       "lastName": "Andrew",
        ///       "carId": 0        
        ///     }
        /// </remarks>
        [HttpPost]
        public IActionResult Create([FromBody] DriverModel driver)
        {
            return Ok(_management.CreateDriver(new(driver)));
        }
        /// <summary>
        /// Update method for Drivers
        /// </summary>
        /// <param name="id">The identifier of the element to be updated</param>
        /// <param name="driver">The update values</param>
        /// <returns>Http status code</returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DriverModel driver)
        {
            return Ok(_management.UpdateDriver(new(id, driver)));
        }
        /// <summary>
        /// Delete method for Drivers
        /// </summary>
        /// <param name="id">The identifier of the element to be removed</param>
        /// <returns>Http status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_management.DeleteDriver(new(id)));
        }
    }
}
