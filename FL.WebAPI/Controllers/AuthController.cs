using FL.AppServices.Implementations;
using FL.AppServices.Messaging.Response.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FL.WebAPI.Controllers
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly JWTManagementService _manager;
        /// <summary>
        /// Authentication controller
        /// </summary>
        /// <param name="manager"></param>
        public AuthController(JWTManagementService manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Generate Jwt token
        /// </summary>
        /// <param name="clientId">Client Identifier</param>
        /// <param name="secret">Client Secret</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Token([FromQuery] string clientId, [FromQuery] string secret)
        {
            var token = _manager.Authenticate(clientId, secret);
            return Ok(await Task.FromResult(new TokenResponse() { Token = token }));
        }
    }
}
