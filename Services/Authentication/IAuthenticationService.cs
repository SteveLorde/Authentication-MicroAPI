using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;

namespace EnterpriseAuthentication_MicroAPI.Services.Authentication;

public interface IAuthenticationService
{
    public Task<bool> LoginUser(UserDTO loginrequest);
    public Task<bool> RegisterUser(UserDTO registerrequest);
}