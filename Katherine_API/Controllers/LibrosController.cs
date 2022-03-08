using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ventas.Libros;

namespace Katherine_API.Controllers
{   
    public class LibrosController : Controller
    {
        //El gusanito permite sobreescribir la ruta raíz
        [Route("~/[controller]/GetLibroXID")]
        [HttpPut]
        public Libro GetLibroXID([FromBody] Libro libro)
        {
            Libro objLibro = Libro.ObtenerLibro(libro.ID, libro.ISBN);
            return objLibro;
        }

        [Route("~/[controller]/GetLibros/")]
        [HttpPut]
        public List<Libro> GetLibros([FromBody] Libro libro)
        {
            List<Libro> objLibros = Libro.ObtenerLibros(libro.ISBN, libro.Titulo, libro.Autor, libro.Descripcion, libro.Editorial, libro.Tipo, libro.Activo);
            return objLibros;
        }

        [Route("~/[controller]/AltaLibro")]
        [HttpPost]
        public bool AltaLibro([FromBody] Libro objLibro)
        {
            bool ret = Libro.AltaLibro(objLibro);
            return ret;
        }

        [Route("~/[controller]/EliminarLibro")]
        [HttpPost]
        public bool EliminarLibro([FromBody] Libro objLibro)
        {
            bool ret = Libro.EliminarLibro(objLibro);
            return ret;
        }

        [Route("~/[controller]/ModificarLibro")]
        [HttpPost]
        public bool ModificarLibro([FromBody] Libro objLibro)
        {
            bool ret = Libro.ModificarLibro(objLibro);
            return ret;
        }
    }
}
