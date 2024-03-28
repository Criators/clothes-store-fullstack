using Clothes.Store.Application.Interfaces;
using Clothes.Store.Application.Interfaces.Services;
using Clothes.Store.Application.Models.InputModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Repository.Services
{
    public class TokenService : ITokenService
    {
        private readonly ICustumer _iCustumer;
        private readonly IConfiguration _configuration;

        public TokenService(ICustumer iCustumer, IConfiguration configuration)
        {
            _iCustumer = iCustumer;
            _configuration = configuration;
        }
        public async Task<string> GenerateToken(AuthenticationInputModel input)
        {
            var custumer = await _iCustumer.GetCustumerByEmailAsync(input.Email);

            if(custumer == null)
                return String.Empty;

            if (input.Email != custumer.Email || !BCrypt.Net.BCrypt.Verify(input.Password, custumer.Password))
                return String.Empty;

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var signinCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name, custumer.CustumerName),
                    new Claim(type: ClaimTypes.Role, custumer.UserType.ToString())
                },
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredential);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
