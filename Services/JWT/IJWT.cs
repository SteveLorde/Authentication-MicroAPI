using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.JWT.Models;

namespace EnterpriseAuthentication_MicroAPI.Services.JWT;

public interface IJWT
{
    public string CreateToken(UserDTO user);
    public void VerifyToken(Token token);
}