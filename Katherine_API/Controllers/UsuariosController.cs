using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosYPermisos;

namespace Katherine_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : Controller
    {
        //El gusanito permite sobreescribir la ruta raíz
        [Route("~/[controller]/GetUsuarioID/{id}")]
        [HttpGet]
        public Usuario GetUsuarioID(int id)
        {
            Usuario objUsu = Usuario.ObtenerUsuario(id);
            return objUsu;
        }

        [Route("~/[controller]/GetUsuario/{usuario}")]
        [HttpGet]
        public Usuario GetUsuario(string usuario)
        {
            Usuario objUsu = Usuario.ObtenerUsuario(0, usuario);
            return objUsu;
        }


    }
}
