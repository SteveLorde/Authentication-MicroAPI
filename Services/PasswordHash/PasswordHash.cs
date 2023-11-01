using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;
using EnterpriseAuthentication_MicroAPI.Data;
using EnterpriseAuthentication_MicroAPI.Data.Models;
using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.PasswordHash.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAuthentication_MicroAPI.Services.PasswordHash;

class PasswordHash : IPasswordHash
{
    private DataContext _db;
    public PasswordHash(DataContext db)
    {
        _db = db;
    }

    public async Task<Hash> HashPassword(UserDTO user)
    {
        string salt = GenerateSalt();
        string hashedpassword = GenerateHashedPassword(user.password, salt);
        Hash userhash = new Hash()
        {
            hash = hashedpassword,
            salt = salt
        };
        return userhash;
    }
    
    private string GenerateHashedPassword(string password, string salt)
    {
        byte[] passwordbytes = Encoding.UTF8.GetBytes(password);
        byte[] saltbytes = Convert.FromBase64String(salt);

        byte[] combinedbytes = new byte[saltbytes.Length + passwordbytes.Length];
        Buffer.BlockCopy(saltbytes,0,combinedbytes, 0, saltbytes.Length);
        Buffer.BlockCopy(passwordbytes,0,combinedbytes, saltbytes.Length, passwordbytes.Length);

        SHA256 sha256 = SHA256.Create();
        byte[] hashedbytes = sha256.ComputeHash(combinedbytes);
        string hashedpassword = Convert.ToBase64String(hashedbytes);
        return hashedpassword;
    }

    public async Task<bool> VerifyPassword(UserDTO loginrequest)
    {
        User usertoverfiy = await _db.Users.FirstAsync(x => x.username == loginrequest.username);
        string passwordtoverify = GenerateHashedPassword(loginrequest.password, usertoverfiy.saltpassword);

        if (passwordtoverify == usertoverfiy.hashedpassword)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    private static string GenerateSalt()
    {
        byte[] salt = new byte[16];
        var rng = new RNGCryptoServiceProvider();
        rng.GetBytes(salt);
        string base64salt = Convert.ToBase64String(salt);
        return base64salt;
    }
    
}