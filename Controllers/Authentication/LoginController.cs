using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAuthentication_MicroAPI.Controllers.Authentication;

[ApiController]
[Route("[Login]")]
public class LoginController : Controller
{
    // GET
    [HttpGet(Name = "UserLogin")]
    public IActionResult Login(UserDTO userlogin)
    {
        
        return Ok();
    }
}