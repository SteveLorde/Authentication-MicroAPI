using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.PasswordHash.DTOs;

namespace EnterpriseAuthentication_MicroAPI.Services.PasswordHash;

public interface IPasswordHash
{
    public Task<Hash> HashPassword(UserDTO user);
    public Task<bool> VerifyPassword(UserDTO loginrequest);
}