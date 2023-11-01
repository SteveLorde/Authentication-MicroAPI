using EnterpriseAuthentication_MicroAPI.Services.Authentication;
using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.JWT;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAuthentication_MicroAPI.Controllers;

[ApiController]
[Route("Authentication")]
public class LoginController : Controller
{
    private IJWT _jwt;

    private IAuthenticationService _auth;

    public LoginController(IJWT jwt, IAuthenticationService auth)
    {
        _jwt = jwt;
        _auth = auth;
    }
    
    [HttpPost("Login")]
    public IActionResult Login(string username, string password)
    {
        UserDTO userlogin = new UserDTO()
        {
            username = username,
            password = password
        };
        //check password
        var check = _auth.LoginUser(userlogin);
        if (check)
        {
            string token = _jwt.CreateToken(userlogin);
            return Ok(token);
        }
        else
        {
            return Ok(false + " login failed");
        }
    }
    
    
    
}