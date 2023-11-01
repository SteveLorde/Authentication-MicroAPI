namespace EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;

public class UserDTO
{
    public string name { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public int corporateid { get; set; }
    public string? department { get; set; }
    public string? role { get; set; }
}