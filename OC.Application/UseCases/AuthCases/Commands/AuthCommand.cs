using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OC.Application.Interfaces.Commands;
using OC.Application.Interfaces.Repositories;
using OC.Contracts.Requests;
using OC.Contracts.Responses;
using OC.Libraries.Classes;
using OC.Libraries.Enums;
using OC.Libraries.Interfaces;
using OC.Validations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OC.Application.UseCases.AuthCases.Commands
{
    public class AuthCommand : IAuthCommand
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IEncryptData _encryptData;

        public AuthCommand(IUserRepository userRepository, IConfiguration configuration, IEncryptData encryptData)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _encryptData = encryptData;
        }

        public async Task<Validation<AuthResponse>> Execute(AuthRequest request)
        {
            var user = await _userRepository.GetLoginCredentials(request.Login, request.Password);

            if (user.Fail) return Validation<AuthResponse>.Failed(user.Error);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.GetValue().Id.ToString()),
                new Claim(ClaimTypes.Name, user.GetValue().Login)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return Validation<AuthResponse>.Succeeded(new AuthResponse(new JwtSecurityTokenHandler().WriteToken(token)));
        }
    }
}