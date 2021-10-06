using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TotalError.OrderSales.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TotalError.OrderSales.Domain.Abstractions.Services;

namespace TotalError.OrderSales.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _settings;
        
        public JwtService(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
        }

        public string GenerateJsonWebToken(Guid userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, userId.ToString()));

            var token = new JwtSecurityToken(claims: claims,
                audience: _settings.Audience,
                issuer: _settings.Issuer,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

