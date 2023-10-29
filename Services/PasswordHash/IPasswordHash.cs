namespace EnterpriseAuthentication_MicroAPI.Services.PasswordHash;

public interface IPasswordHash
{
    
    public string HashPassword();
    public bool VerifyPassword();
    
}