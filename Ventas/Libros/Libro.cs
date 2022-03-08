using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Libros
{
    public class Libro
    {
        #region "Atributos"
        private int _id;
        #endregion

        #region "Propiedades"
        public int ID
        {
            get
            {
                return this._id;
            }

            set
            {
                if (this._id == 0)
                {
                    this._id = value;
                }
            }
        }

        public string ISBN
        {
            get; set;
        }
        public string Titulo
        {
            get; set;
        }
        public string Subtitulo
        {
            get; set;
        }
        public string Idioma
        {
            get; set;
        }
        public string Autor
        {
            get; set;
        }
        public string Tipo
        {
            get; set;
        }
        public string Editorial
        {
            get; set;
        }
        public string Coleccion
        {
            get; set;
        }
        public string Descripcion
        {
            get; set;
        }

        public DateTime FechaPublicacion
        {
            get; set;
        }
        public decimal Precio
        {
            get; set;
        }
        public int CantPaginas
        {
            get; set;
        }
        public bool Activo
        {
            get; set;
        }
        #endregion

        #region "Constructores"
        public Libro()
        {

        }

        public Libro(DataRow dr)
        {
            this.ID = Convert.ToInt32(dr["ID"].ToString());
            this.ISBN = dr["ISBN"].ToString();
            this.Titulo = dr["Titulo"].ToString();
            this.Subtitulo = dr["Subtitulo"].ToString();
            this.Idioma = dr["Idioma"].ToString();
            this.Autor = dr["Autor"].ToString();
            this.Tipo = dr["Tipo"].ToString();
            this.Editorial = dr["Editorial"].ToString();
            this.Coleccion = dr["Coleccion"].ToString();
            this.Descripcion = dr["Descripcion"].ToString();

            this.FechaPublicacion = DateTime.Parse(dr["FechaPublicacion"].ToString());
            this.Precio = Convert.ToDecimal(dr["Precio"].ToString());
            this.CantPaginas = Convert.ToInt32(dr["CantPaginas"].ToString());

            this.Activo = Convert.ToBoolean(dr["Activo"].ToString());
        }
        #endregion


        public static List<Libro> ObtenerLibros(string ISBN, string titulo, string autor, string descripcion, string editorial, string tipo, bool soloActivos = true)
        {
            try
            {
                List<Libro> libros = new List<Libro>();

                //Inicializo conexión
                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("ObtenerLibros");

                //Agrego parámetros
                objBD.AgregarParametroNulo("ID");
                objBD.AgregarParametro("ISBN", ISBN);
                objBD.AgregarParametro("Titulo", titulo);
                objBD.AgregarParametro("Autor", autor);
                objBD.AgregarParametro("Descripcion", descripcion);
                objBD.AgregarParametro("Editorial", editorial);
                objBD.AgregarParametro("Tipo", tipo);
                objBD.AgregarParametro("SoloActivos", soloActivos);

                DataTable dt = objBD.EjecutarQuery();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Libro l = new Libro(dr);

                        libros.Add(l);
                    }
                }

                return libros;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool AltaLibro(Libro objLibro)
        {
            try
            {
                bool retorno = false;

                //Inicializo conexión
                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("ABMLibros");

                //Agrego parámetros
                objBD.AgregarParametro("ID", objLibro.ID);
                objBD.AgregarParametro("ISBN", objLibro.ISBN);
                objBD.AgregarParametro("Titulo", objLibro.Titulo);
                objBD.AgregarParametro("Subtitulo", objLibro.Subtitulo);
                objBD.AgregarParametro("Idioma", objLibro.Idioma);
                objBD.AgregarParametro("Descripcion", objLibro.Descripcion);
                objBD.AgregarParametro("Autor", objLibro.Autor);
                objBD.AgregarParametro("Tipo", objLibro.Tipo);
                objBD.AgregarParametro("Editorial", objLibro.Editorial);
                objBD.AgregarParametro("Coleccion", objLibro.Coleccion);
                objBD.AgregarParametro("Precio", objLibro.Precio);
                objBD.AgregarParametro("CantPaginas", objLibro.CantPaginas);
                objBD.AgregarParametro("FechaPublicacion", objLibro.FechaPublicacion);
                objBD.AgregarParametro("Activo", objLibro.Activo);
                objBD.AgregarParametroNulo("Eliminar");

                int ret = objBD.EjecutarRetorno();

                if(ret == 1)
                {
                    retorno = true;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Libro ObtenerLibro(int id = 0, string ISBN = "", bool soloActivos = true)
        {
            try
            {
                Libro objLibro = null;

                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("ObtenerLibros");

                if (id == 0)
                {
                    objBD.AgregarParametroNulo("ID");
                }
                else
                {
                    objBD.AgregarParametro("ID", id);
                }

                if (ISBN == "")
                {
                    objBD.AgregarParametroNulo("ISBN");
                }
                else
                {
                    objBD.AgregarParametro("ISBN", ISBN);
                }

                objBD.AgregarParametroNulo("Titulo");
                objBD.AgregarParametroNulo("Autor");
                objBD.AgregarParametroNulo("Descripcion");
                objBD.AgregarParametroNulo("Editorial");
                objBD.AgregarParametroNulo("Tipo");

                objBD.AgregarParametro("SoloActivos", soloActivos);

                DataTable dt = objBD.EjecutarQuery();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        objLibro = new Libro(dr);
                    }
                }

                return objLibro;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool EliminarLibro(Libro objLibro)
        {
            try
            {
                bool retorno = false;

                //Inicializo conexión
                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("ABMLibros");

                //Agrego parámetros
                objBD.AgregarParametro("ID", objLibro.ID);
                objBD.AgregarParametro("Eliminar", true);

                int ret = objBD.EjecutarRetorno();

                if (ret == 1)
                {
                    retorno = true;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ModificarLibro(Libro objLibro)
        {
            try
            {
                bool retorno = false;

                //Inicializo conexión
                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("ABMLibros");

                //Agrego parámetros
                objBD.AgregarParametro("ID", objLibro.ID);
                objBD.AgregarParametro("ISBN", objLibro.ISBN);
                objBD.AgregarParametro("Titulo", objLibro.Titulo);
                objBD.AgregarParametro("Subtitulo", objLibro.Subtitulo);
                objBD.AgregarParametro("Idioma", objLibro.Idioma);
                objBD.AgregarParametro("Descripcion", objLibro.Descripcion);
                objBD.AgregarParametro("Autor", objLibro.Autor);
                objBD.AgregarParametro("Tipo", objLibro.Tipo);
                objBD.AgregarParametro("Editorial", objLibro.Editorial);
                objBD.AgregarParametro("Coleccion", objLibro.Coleccion);
                objBD.AgregarParametro("Precio", objLibro.Precio);
                objBD.AgregarParametro("CantPaginas", objLibro.CantPaginas);
                objBD.AgregarParametro("FechaPublicacion", objLibro.FechaPublicacion);
                objBD.AgregarParametro("Activo", objLibro.Activo);
                objBD.AgregarParametroNulo("Eliminar");

                int ret = objBD.EjecutarRetorno();

                if (ret == 1)
                {
                    retorno = true;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public static int GuardarUsuario(Usuario pUsuario)
        //{
        //    try
        //    {
        //        int retorno = 0;

        //        IBaseDatos objBD = BaseConexion.ObtenerBD();
        //        objBD.IniciarComandoStoredProcedure("ABMUsuarios");

        //        if (pUsuario.ID > 0)
        //        {
        //            objBD.AgregarParametro("ID", pUsuario.ID);
        //        }
        //        else
        //        {
        //            objBD.AgregarParametroNulo("ID");
        //        }

        //        objBD.AgregarParametro("Usuario", pUsuario.User);
        //        objBD.AgregarParametro("Nombre", pUsuario.Nombre);
        //        objBD.AgregarParametro("Direccion", pUsuario.Direccion);
        //        objBD.AgregarParametro("Email", pUsuario.Email);
        //        objBD.AgregarParametro("Telefono", pUsuario.Telefono);
        //        objBD.AgregarParametro("Telefono2", pUsuario.Telefono2);
        //        objBD.AgregarParametro("UltimoAcceso", pUsuario.UltimoAcceso);

        //        objBD.AgregarParametroRetorno("Retorno");

        //        retorno = objBD.EjecutarRetorno();

        //        return retorno;

        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //    }
        //}

        //public static int EliminarUsuario(Usuario pUsuario)
        //{
        //    try
        //    {
        //        int retorno = 0;

        //        IBaseDatos objBD = BaseConexion.ObtenerBD();
        //        objBD.IniciarComandoStoredProcedure("ABMUsuarios");

        //        if (pUsuario.ID > 0)
        //        {
        //            objBD.AgregarParametro("ID", pUsuario.ID);
        //        }
        //        else
        //        {
        //            objBD.AgregarParametroNulo("ID");
        //        }

        //        objBD.AgregarParametro("Usuario", pUsuario.User);
        //        objBD.AgregarParametro("Nombre", pUsuario.Nombre);
        //        objBD.AgregarParametro("Direccion", pUsuario.Direccion);
        //        objBD.AgregarParametro("Email", pUsuario.Email);
        //        objBD.AgregarParametro("Telefono", pUsuario.Telefono);
        //        objBD.AgregarParametro("Telefono2", pUsuario.Telefono2);
        //        objBD.AgregarParametro("UltimoAcceso", pUsuario.UltimoAcceso);

        //        objBD.AgregarParametroRetorno("Retorno");

        //        retorno = objBD.EjecutarRetorno();

        //        return retorno;

        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //    }
        //}
    }
}
