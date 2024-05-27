using FL.AppServices.Implementations;
using FL.Infrastructure.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FL.WebAPI.Controllers
{
    /// <summary>
    /// Controller for managing Laps
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LapsController : ControllerBase
    {
        /// <summary>
        /// Database context object
        /// </summary>
        private readonly ILapManagementService _management;
        /// <summary>
        /// Laps controller
        /// </summary>
        /// <param name="management">Dependancy injection object</param>
        public LapsController(ILapManagementService management)
        {
            _management = management;
        }
        /// <summary>
        /// Get method for Laps
        /// </summary>
        /// <returns>List of all Laps</returns>
        [HttpGet("All")]
        public IActionResult Get()
        {
            return Ok(_management.GetLaps());
        }
        /// <summary>
        /// Get method for Laps
        /// </summary>
        /// <param name="id">the identifier of the Lap</param>
        /// <returns>A Lap object</returns>
        [HttpGet("Find/{id}")]
        public IActionResult Find([FromRoute] int id)
        {
            return Ok(_management.GetLap(id));
        }
        /// <summary>
        /// Get method for Laps
        /// </summary>
        /// <param name="currentPage">The current page</param>
        /// <param name="elementsPerPage">The nummber of Laps per page</param>
        /// <returns>List of all Lapps with paging</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] int currentPage, int elementsPerPage)
        {
            return Ok(_management.GetLaps(new(currentPage, elementsPerPage)));
        }
        /// <summary>
        /// Create method for Laps
        /// </summary>
        /// <param name="lap">The lap object to be inserted</param>
        /// <returns>Http status code</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/Lap
        ///     {        
        ///       "sector1": "00:00:00.0",
        ///       "sector2": "00:00:00.0",
        ///       "sector3": "00:00:00.0",
        ///       "lapTime": "00:00:00.0",
        ///       "driverId": 0
        ///     }
        /// </remarks>
        [HttpPost]
        public IActionResult Create([FromBody] LapModel lap)
        {
            return Ok(_management.CreateLap(new(lap)));
        }
        /// <summary>
        /// Update method for Laps
        /// </summary>
        /// <param name="id">The identifier of the element to be updated</param>
        /// <param name="lap">The update values</param>
        /// <returns>Http status code</returns>
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] LapModel lap)
        {
            return Ok(_management.UpdateLap(new(id, lap)));
        }
        /// <summary>
        /// Delete method for Laps
        /// </summary>
        /// <param name="id">The identifier of the element to be removed</param>
        /// <returns>Http status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            return Ok(_management.DeleteLap(new(id)));
        }
    }
}
