using FL.AppServices.Interfaces;
using FL.Data.Context;
using FL.Infrastructure.Messaging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FL.AppServices.Implementations
{
    public class JWTManagementService : IJWTManagementService
    {
        private readonly FLDbContext _context;
        private readonly string _tokenKey;
        public JWTManagementService(IOptions<AuthOptions> options, FLDbContext context)
        {
            _context = context;
            _tokenKey = options.Value.TokenKey;
        }
        public string? Authenticate(string clientId, string secret)
        {
            if (!_context.Clients.Any(x => x.Name == clientId && x.Secret == secret))
            {
                return null;
            }
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenKey);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, clientId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

    }
}
