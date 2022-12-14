using ApiAuth.DTOs;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] LoginDTO request) {
            //Recupera usuário
            var user = UserRepository.Get(request.Username, request.Password);
            if (user == null)
                return BadRequest("Usuário não informado");

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token =token
            };
        }
    }
}
