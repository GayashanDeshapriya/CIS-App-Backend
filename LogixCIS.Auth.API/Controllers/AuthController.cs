using LogixCIS.Auth.API.Models;
using LogixCIS.Auth.API.Repositories;
using LogixCIS.Auth.API.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LogixCIS.Auth.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService authService;

        public AuthController(IAuthService AuthService, IConfiguration configuration)
        {
            authService = AuthService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(Login loginData)
        {
            var result = await authService.Login(loginData);

            if (result.Status)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized(result);
            }
        }

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] User login)
        //{
        //    var user = _userRepository.GetUser(login.Username, login.Password);
        //    if (user == null) return Unauthorized();

        //    var token = GenerateJwtToken(user);
        //    return Ok(new { token });
        //}

       
    }

}
