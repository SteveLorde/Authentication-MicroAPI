using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.JWT.Models;
using Microsoft.IdentityModel.Tokens;

namespace EnterpriseAuthentication_MicroAPI.Services.JWT;


class Jwt : IJWT
{
    private const string jwtseckey = "123456";

    private IConfiguration _config;

    public Jwt(IConfiguration config)
    {
        _config = config;
    }

    public string CreateToken(UserDTO user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtseckey));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        
        return jwt;
    }

    public void VerifyToken(Token token)
    {
        
    }
    
}