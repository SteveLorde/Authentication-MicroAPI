namespace EnterpriseAuthentication_MicroAPI.Services.PasswordHash.DTOs;

public class Hash
{
    public string hash { get; set; }
    public string salt { get; set; }
}