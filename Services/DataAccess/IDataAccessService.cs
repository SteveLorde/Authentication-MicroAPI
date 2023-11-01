using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;

namespace EnterpriseAuthentication_MicroAPI.Services.DataAccess;

public interface IDataAccessService
{
    public Task GetUsers();
    public Task GetUser(int username);
    public Task CreateUser(UserDTO newuser);
    
}