using EnterpriseAuthentication_MicroAPI.Data;
using EnterpriseAuthentication_MicroAPI.Data.Models;
using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.PasswordHash;
using EnterpriseAuthentication_MicroAPI.Services.PasswordHash.DTOs;

namespace EnterpriseAuthentication_MicroAPI.Services.DataAccess;

class DataAccessService : IDataAccessService
{

    private DataContext _db;
    private IPasswordHash _pass;

    public DataAccessService(DataContext db, IPasswordHash pass)
    {
        _db = db;
        _pass = pass;
    }
    
    
    public void GetUsers()
    {
        throw new NotImplementedException();
    }

    public void GetUser(int username)
    {
        throw new NotImplementedException();
    }

    public void CreateUser(UserDTO usertoregister)
    {
        //get hashed password
        Hash hashdata = _pass.HashPassword(usertoregister);

        User newuser = new User
        {
            corporateid = usertoregister.corporateid,
            name = usertoregister.name,
            username = usertoregister.username,
            vanilla_password = usertoregister.password,
            saltpassword = hashdata.salt,
            hashedpassword = hashdata.hash,
            corporaterole = usertoregister.role,
            department = usertoregister.department
        };
        
        
    }
}