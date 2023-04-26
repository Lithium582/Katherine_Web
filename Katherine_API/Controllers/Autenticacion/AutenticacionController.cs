using Katherine_API.Extensions;
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
    //El gusanito permite sobreescribir la ruta raíz
    [Route("~/[controller]")]
    [ApiController]
    public class AutenticacionController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;
        public AutenticacionController(JwtSettings jwtSettings)
        {
            this._jwtSettings = jwtSettings;
        }

        //public AutenticacionController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        [Route("Login")]
        [HttpPut]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                var Token = new UserTokens();
                var user = Usuario.Login(model.Usuario, model.Password);
                if (user != null)
                {
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        EmailId = user.Email,
                        GuidId = Guid.NewGuid(),
                        UserName = user.User,
                        Id = user.ID,
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Wrong password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
