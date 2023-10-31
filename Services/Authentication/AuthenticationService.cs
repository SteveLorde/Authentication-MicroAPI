using EnterpriseAuthentication_MicroAPI.Data;
using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.PasswordHash;

namespace EnterpriseAuthentication_MicroAPI.Services.Authentication;

class AuthenticationService : IAuthenticationService
{

    private IPasswordHash _hashservice;
    private DataContext _db;

    public AuthenticationService(DataContext db,IPasswordHash hashservice)
    {
        _db = db;
        _hashservice = hashservice;
    }
    
        public async Task<bool> LoginUser(UserDTO loginrequest)
    {
        try
        {
            bool checklogin = false;
            //1st, check username in database
            bool checkuser = _db.Users.Any(x => x.username == loginrequest.username);
            if (checkuser)
            {
                //2nd verify password
                bool checkpassword = _hashservice.VerifyPassword(loginrequest);
                if (checkpassword)
                {
                    checklogin = true;
                }
            }
            else
            {
                checklogin = false;
            }
            
            return checklogin;
        }
        
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> RegisterUser(UserDTO registerrequest)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}