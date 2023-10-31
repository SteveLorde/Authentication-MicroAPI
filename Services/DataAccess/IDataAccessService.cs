using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;

namespace EnterpriseAuthentication_MicroAPI.Services.DataAccess;

public interface IDataAccessService
{
    public void GetUsers();
    public void GetUser(int username);
    public void CreateUser(UserDTO newuser);
    
}