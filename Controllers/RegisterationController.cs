using EnterpriseAuthentication_MicroAPI.Services.Authentication;
using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAuthentication_MicroAPI.Controllers;

[ApiController]
[Route("Register")]
public class RegisterationController : Controller
{
    
    private IAuthenticationService _auth;

    public RegisterationController(IAuthenticationService auth)
    {
        _auth = auth;
    }
    
    // POST REGISTER
    [HttpPost("RegisterUser")]
    public async Task<IActionResult> Register(UserDTO newuser)
    {
        bool check = await _auth.RegisterUser(newuser);
        return Ok(check);
    }


}