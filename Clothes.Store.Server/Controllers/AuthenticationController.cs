using Clothes.Store.Application.Interfaces.Services;
using Clothes.Store.Domain.Entities;
using Clothes.Store.Application.Models.InputModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Store.Server.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly ITokenService _tokenService;

        public AuthenticationController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticationInputModel input)
        {
            var token = await _tokenService.GenerateToken(input);
            if (token == "") 
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
