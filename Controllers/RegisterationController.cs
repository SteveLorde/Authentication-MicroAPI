using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAuthentication_MicroAPI.Controllers;

public class RegisterationController : Controller
{
    // POST REGISTER
    public IActionResult Register(UserDTO newuser)
    {
        return Ok();
    }
}