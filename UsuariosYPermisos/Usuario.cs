using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using AccesoADatos;
using System.Data;

namespace UsuariosYPermisos
{
    public class Usuario
    {
        #region "Atributos"
        private int _id;
        public static string algo = "";
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

        public string User
        {
            get; set;
        }

        public string Nombre
        {
            get; set;
        }
        public string Nombre2
        {
            get; set;
        }
        public string Apellido
        {
            get; set;
        }
        public string Apellido2
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string Telefono
        {
            get; set;
        }

        public string Telefono2
        {
            get; set;
        }

        public string Direccion
        {
            get; set;
        }

        public DateTime UltimoAcceso
        {
            get; set;
        }
        public bool Activo
        {
            get; set;
        }
        #endregion

        #region "Constructores"
        public Usuario()
        {

        }

        public Usuario(DataRow dr)
        {
            this.ID = Convert.ToInt32(dr["ID"].ToString());
            this.User = dr["Usuario"].ToString();
            this.Nombre = dr["Nombre"].ToString();
            this.Nombre2 = dr["Nombre2"].ToString();
            this.Apellido = dr["Apellido"].ToString();
            this.Apellido2 = dr["Apellido2"].ToString();
            this.Email = dr["Email"].ToString();
            this.Telefono = dr["Telefono"].ToString();
            this.Telefono2 = dr["Telefono2"].ToString();
            this.Direccion = dr["Direccion"].ToString();
            this.UltimoAcceso = DateTime.Parse(dr["UltimoAcceso"].ToString());
            this.Activo = Convert.ToBoolean(dr["Activo"].ToString());
        }

        //public Usuario(string userName) : base(userName)
        //{
        //}
        #endregion

        public static List<Usuario> ObtenerUsuarios(string usuario, string nombre, bool soloActivos = true)
        {
            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                //Inicializo conexión
                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("ObtenerUsuarios");

                //Agrego parámetros
                objBD.AgregarParametroNulo("ID");
                objBD.AgregarParametro("Usuario", usuario);
                objBD.AgregarParametro("Nombre", nombre);
                objBD.AgregarParametro("SoloActivos", soloActivos);

                DataTable dt = objBD.EjecutarQuery();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Usuario u = new Usuario(dr);

                        usuarios.Add(u);
                    }
                }

                return usuarios;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Usuario ObtenerUsuario(int id = 0, string usuario = "", bool soloActivos = true)
        {
            try
            {
                Usuario objUsuario = null;

                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("ObtenerUsuarios");

                if (id == 0)
                {
                    objBD.AgregarParametroNulo("ID");
                }
                else
                {
                    objBD.AgregarParametro("ID", id);
                }

                if (usuario == "")
                {
                    objBD.AgregarParametroNulo("Usuario");
                }
                else
                {
                    objBD.AgregarParametro("Usuario", usuario);
                }

                objBD.AgregarParametroNulo("Nombre");
                objBD.AgregarParametro("SoloActivos", soloActivos);

                DataTable dt = objBD.EjecutarQuery();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        objUsuario = new Usuario(dr);
                    }
                }

                return objUsuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Usuario Login (string pUsuario, string pPassword)
        {
            try
            {
                Usuario objUsuario = null;

                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("Login");

                objBD.AgregarParametro("Usuario", pUsuario);
                objBD.AgregarParametro("Password", pPassword);

                DataTable dt = objBD.EjecutarQuery();
                if (dt.Rows.Count == 1)
                {
                    DataRow dr = dt.Rows[0];
                    objUsuario = new Usuario(dr);
                }

                return objUsuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int GuardarUsuario(Usuario pUsuario)
        {
            try
            {
                int retorno = 0;

                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("ABMUsuarios");

                if (pUsuario.ID > 0)
                {
                    objBD.AgregarParametro("ID", pUsuario.ID);
                }
                else
                {
                    objBD.AgregarParametroNulo("ID");
                }

                objBD.AgregarParametro("Usuario", pUsuario.User);
                objBD.AgregarParametro("Nombre", pUsuario.Nombre);
                objBD.AgregarParametro("Direccion", pUsuario.Direccion);
                objBD.AgregarParametro("Email", pUsuario.Email);
                objBD.AgregarParametro("Telefono", pUsuario.Telefono);
                objBD.AgregarParametro("Telefono2", pUsuario.Telefono2);
                objBD.AgregarParametro("UltimoAcceso", pUsuario.UltimoAcceso);

                objBD.AgregarParametroRetorno("Retorno");

                retorno = objBD.EjecutarRetorno();

                return retorno;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static int EliminarUsuario(Usuario pUsuario)
        {
            try
            {
                int retorno = 0;

                IBaseDatos objBD = BaseConexion.ObtenerBD();
                objBD.IniciarComandoStoredProcedure("ABMUsuarios");

                if (pUsuario.ID > 0)
                {
                    objBD.AgregarParametro("ID", pUsuario.ID);
                }
                else
                {
                    objBD.AgregarParametroNulo("ID");
                }

                objBD.AgregarParametro("Usuario", pUsuario.User);
                objBD.AgregarParametro("Nombre", pUsuario.Nombre);
                objBD.AgregarParametro("Direccion", pUsuario.Direccion);
                objBD.AgregarParametro("Email", pUsuario.Email);
                objBD.AgregarParametro("Telefono", pUsuario.Telefono);
                objBD.AgregarParametro("Telefono2", pUsuario.Telefono2);
                objBD.AgregarParametro("UltimoAcceso", pUsuario.UltimoAcceso);

                objBD.AgregarParametroRetorno("Retorno");

                retorno = objBD.EjecutarRetorno();

                return retorno;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
