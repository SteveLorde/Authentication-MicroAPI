using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.PasswordHash.DTOs;

namespace EnterpriseAuthentication_MicroAPI.Services.PasswordHash;

public interface IPasswordHash
{
    public Hash HashPassword(UserDTO user);
    public bool VerifyPassword(UserDTO loginrequest);
}