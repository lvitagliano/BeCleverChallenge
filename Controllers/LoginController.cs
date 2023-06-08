using BeCleverChallenge.Services.User.Dto;
using Microsoft.AspNetCore.Mvc;
using BeCleverChallenge.Services.User;
using BeCleverChallenge.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeCleverChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        IAutenticateService _autenticateService;
        public LoginController(IAutenticateService autenticateService)
        {
            _autenticateService = autenticateService;
        }

        [HttpPost]
        public IActionResult login(UserLogin userData)
        {
            var userLogin = _autenticateService.LoginService(userData);

            if (userLogin != null)
            {
                var token = _autenticateService.Generate(userLogin);
                return Ok(token);
            }
            return NotFound("User NotFound");
        }

    }
}
