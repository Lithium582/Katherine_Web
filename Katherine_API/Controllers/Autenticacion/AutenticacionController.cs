using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsuariosYPermisos;

namespace Katherine_API.Controllers.Autenticacion
{
    [Route("~/[controller]")]
    [ApiController]
    public class AutenticacionController : Controller
    {
        private readonly IConfiguration _configuration;

        public AutenticacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //El gusanito permite sobreescribir la ruta raíz
        [Route("Login")]
        [HttpPut]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = Usuario.Login(model.Usuario, model.Password);
            if (user != null)
            {
                //var userRoles = await userManager.GetRolesAsync(user);

                //var authClaims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, user.UserName),
                //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //};

                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    //claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
}
