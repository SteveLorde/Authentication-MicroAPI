using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;

namespace EnterpriseAuthentication_MicroAPI.Services.Authentication;

public interface IAuthenticationService
{
    public bool LoginUser(UserDTO loginrequest);
    public bool RegisterUser(UserDTO registerrequest);
}