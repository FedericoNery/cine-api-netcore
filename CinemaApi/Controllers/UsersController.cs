using AuthenticationPlugin;
using CinemaApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace CinemaApi.Controllers
{
    [Route("api/[controller]/[action]")] // como todos los métodos van a usar el nombre del método, es preferible pasarlo por acá y listo
    //[Authorize]//Estamos protegiendo el controller acá
               //Basicamente estamos controlando que nadie que no este logueado pueda pegarle a la API
    [ApiController]


    public class UsersController : ControllerBase
    {
        private CinemaDbContext _dbContext;
        private IConfiguration _configuration;
        private readonly AuthService _auth;

        public UsersController(CinemaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _auth = new AuthService(_configuration);
        }

        [HttpPost]
        //[Authorize]//Estamos protegiendo el método acá
        /*public IActionResult Register([FromBody] User user)
        {
            var userWithSameEmail = _dbContext.Users.Where(x => x.Email.Equals(user.Email)).SingleOrDefault();

            if (userWithSameEmail != null)
            {
                return BadRequest("Usuario con el mismo email ya existe");
            }
            var userObj = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = SecurePasswordHasherHelper.Hash(user.Password),
                Role = "Users"
            };

            _dbContext.Users.Add(userObj);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }*/

        //Crear metodos get para authorize de users y de admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public string EsAdmin()
        {
            return "Tiene rol de admin";
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Users")]
        public string EsUser(int id)
        {
            return "Tiene rol de users";
        }

        /*[HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var userEmail = _dbContext.Users.FirstOrDefault(x => x.Email.Equals(user.Email));

            if (userEmail == null)
            {
                return NotFound("No se encontró al usuario");
            }

            if (!SecurePasswordHasherHelper.Verify(user.Password, userEmail.Password))
            {
                return Unauthorized("No está autorizado el usuario");
            }
            var claims = new[]{
               new Claim(JwtRegisteredClaimNames.Email, user.Email),
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.Role, userEmail.Role)
            };

            var token = _auth.GenerateAccessToken(claims);

            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                user_id = userEmail.Id
            });
        }*/
    }
}
