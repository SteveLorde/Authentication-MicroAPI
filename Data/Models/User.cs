namespace EnterpriseAuthentication_MicroAPI.Data.Models;

public class User
{
    public int UserId { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public string vanilla_password { get; set; }
    public string hashedpassword { get; set; }
}