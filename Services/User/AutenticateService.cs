

using BeCleverChallenge.Models;
using BeCleverChallenge.Services.User.Dto;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BeCleverChallenge.Services.User
{
    public class AutenticateService: IAutenticateService
    {
        IConfiguration _config;
        BeCleverContext _context;
        public AutenticateService(IConfiguration config, BeCleverContext context)
        {
            _config = config;
            _context = context;
        }
        public UserModel LoginService(UserLogin input)
        {
            var currentUser = _context.User.Where(x => x.UserName == input.UserName && x.Password == input.Password).FirstOrDefault();

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        public string Generate(UserModel currentUser)
        {
            var jwt = _config.GetSection("Jwt").Get<JwtModel>();
            var claims = new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, currentUser.Name),
                        new Claim("user", currentUser.Id.ToString()),
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(
                            jwt.Issuer,
                            jwt.Audience,
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(60),
                            signingCredentials: signIn
                        );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }

    }
}
