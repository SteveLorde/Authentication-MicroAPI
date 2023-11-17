using EnterpriseAuthentication_MicroAPI.Data;
using EnterpriseAuthentication_MicroAPI.Data.Models;
using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.PasswordHash;
using EnterpriseAuthentication_MicroAPI.Services.PasswordHash.DTOs;
using Microsoft.EntityFrameworkCore;

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
                bool checkpassword = await _hashservice.VerifyPassword(loginrequest);
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
            bool checkifexist = await _db.Users.AnyAsync(x => x.username == registerrequest.username);
            if (!checkifexist)
            {
                Hash newpassword = await _hashservice.HashPassword(registerrequest);
                User newuser = new User
                {
                    corporateid = registerrequest.corporateid,
                    name = registerrequest.name,
                    username = registerrequest.username,
                    saltpassword = newpassword.salt,
                    hashedpassword = newpassword.hash,
                    corporaterole = registerrequest.role,
                    department = registerrequest.department
                };
                await _db.Users.AddAsync(newuser);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}