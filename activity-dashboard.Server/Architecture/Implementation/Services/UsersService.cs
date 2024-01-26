using activity_dashboard.Server.Architecture.Interfaces.IRepository;
using activity_dashboard.Server.Architecture.Interfaces.IServices;
using activity_dashboard.Server.Architecture.Requests;
using activity_dashboard.Server.Architecture.Responses;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace activity_dashboard.Server.Architecture.Implementation.Services
{
    public class UsersService : IUsersService
    {
        IUserRepository _userRepository;
        IConfiguration _configuration;

        public UsersService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public ReturnResponse LoginAsync(TokenRequest model)
        {
            var user = _userRepository.UserLogin(model);
            if (user == null)
            {
                return new ReturnResponse { isSuccessful = false, Message = "Please enter login details" };
            }
            return new ReturnResponse { isSuccessful = true, Data = GenerateJwtToken(user.UserName, user.Id) };
        }

        private string GenerateJwtToken(string username, int userId)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier , userId.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
