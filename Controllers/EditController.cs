using EnterpriseAuthentication_MicroAPI.Services.Authentication;
using EnterpriseAuthentication_MicroAPI.Services.DataAccess.DTOs;
using EnterpriseAuthentication_MicroAPI.Services.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAuthentication_MicroAPI.Controllers;

    
[Authorize]
[ApiController]
[Route("Edit")]
public class EditController : Controller
{
    private IJWT _jwt;
    private IAuthenticationService _auth;

    public EditController(IJWT jwt, IAuthenticationService auth)
    {
        _jwt = jwt;
        _auth = auth;   
    }
    
    [HttpPost("UpdateUser")]
    public async Task<IActionResult> UpdateUser(UserDTO updateduser)
    {

        return Ok(true);
    }
    
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteuUser(UserDTO updateduser)
    {
        return Ok(true);
    }
    
    
    
}