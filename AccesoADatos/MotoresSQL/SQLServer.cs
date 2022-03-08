using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.MotoresSQL
{
    public class SQLServer : BaseDatos
    {
        #region "Atributos"
        private bool _testing;
        private SqlCommand _comando;

        #endregion

        #region "Propiedades"
        private string ConexionLocalhost
        {
            get
            {
                string conn = string.Format("data source={0}; initial catalog={1}; persist security info=True; Integrated Security=SSPI; MultipleActiveResultSets=true;", this.Servidor, this.Base);
                return conn;
            }
        }

        private string Conexion
        {
            get
            {
                string conn = string.Format("data source={0}; initial catalog={1}; persist security info=True; MultipleActiveResultSets=true; User Id={2};Password={3}", this.Servidor, this.Base, this.Usuario, this.Pass);
                return conn;
            }
        }

        private string GetConnectionString
        {
            get
            {
                if (this._testing)
                {
                    return this.ConexionLocalhost;
                }
                else
                {
                    return this.Conexion;
                }
            }

        }
        #endregion

        #region "Constructores"
        public SQLServer(Configuracion config)
            :base(config)
        {
            this._testing = (config.Usuario == "" && config.Pass == "");
            _comando = new SqlCommand();
        }

        #endregion

        #region "Inicialización de comandos"

        public override void IniciarComandoStoredProcedure(string pNombreSP)
        {
            this._comando.CommandText = pNombreSP;
            this._comando.CommandType = System.Data.CommandType.StoredProcedure;
        }

        #endregion

        #region "Ejecución"
        public override DataTable EjecutarQuery()
        {   
            DataTable dt = new DataTable();

            using (SqlConnection conexion = new SqlConnection(this.GetConnectionString))
            {
                conexion.Open();
                this._comando.Connection = conexion;

                SqlDataReader dr = this._comando.ExecuteReader();
                dt.Load(dr);

                conexion.Close();
            }

            return dt;
        }

        public override int EjecutarRetorno()
        {
            int ret = 0;

            using (SqlConnection conexion = new SqlConnection(this.GetConnectionString))
            {
                SqlParameter parametroRetorno = ObtenerValorParametroRetorno();

                if (parametroRetorno == null)
                {
                    parametroRetorno = AgregarParametroRetorno("Retorno");
                }

                conexion.Open();
                this._comando.Connection = conexion;

                SqlDataReader dr = this._comando.ExecuteReader();

                ret = Convert.ToInt32(parametroRetorno.Value);

                conexion.Close();
            }

            return ret;
        }

        public override int EjecutarEscalar()
        {
            int ret = 0;

            //using (SqlConnection conexion = new SqlConnection(this.GetConnectionString))
            //{
            //    conexion.Open();
            //    this._comando.Connection = conexion;

            //    SqlDataReader dr = this._comando.ExecuteReader();
            //    ret = ObtenerValorParametroRetorno();
            //    conexion.Close();
            //}

            return ret;
        }

        protected override SqlParameter ObtenerValorParametroRetorno()
        {
            int ret = 0;
            SqlParameter retPar = (from SqlParameter p in this._comando.Parameters
                                   where p.Direction == ParameterDirection.ReturnValue
                                   select p).FirstOrDefault();

            return retPar;
        }

        #endregion

        #region "Manejo de parámetros"
        public override void AgregarParametro(string pNombre, string pValor)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.VarChar);
            par.Value = pValor;
            par.Direction = ParameterDirection.Input;

            this._comando.Parameters.Add(par);
        }

        public override void AgregarParametro(string pNombre, int pValor)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.Int);
            par.Value = pValor;
            par.Direction = ParameterDirection.Input;

            this._comando.Parameters.Add(par);
        }

        public override void AgregarParametro(string pNombre, bool pValor)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.Bit);
            par.Value = pValor;
            par.Direction = ParameterDirection.Input;

            this._comando.Parameters.Add(par);
        }

        public override void AgregarParametro(string pNombre, DateTime pValor)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.DateTime);
            par.Value = pValor.ToString("s");
            par.Direction = ParameterDirection.Input;

            this._comando.Parameters.Add(par);
        }

        public override void AgregarParametro(string pNombre, decimal pValor)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.Decimal);
            par.Value = pValor;
            par.Direction = ParameterDirection.Input;

            this._comando.Parameters.Add(par);
        }

        public override void AgregarParametro(string pNombre, float pValor)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.Float);
            par.Value = pValor;
            par.Direction = ParameterDirection.Input;

            this._comando.Parameters.Add(par);
        }

        public override void AgregarParametro(string pNombre, double pValor)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.Float);
            par.Value = pValor;
            par.Direction = ParameterDirection.Input;

            this._comando.Parameters.Add(par);
        }

        public override void AgregarParametro(string pNombre, char pValor)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.Char);
            par.Value = pValor;
            par.Direction = ParameterDirection.Input;

            this._comando.Parameters.Add(par);
        }

        public override void AgregarParametro(string pNombre, long pValor)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.BigInt);
            par.Value = pValor;
            par.Direction = ParameterDirection.Input;

            this._comando.Parameters.Add(par);
        }

        public override void AgregarParametroNulo(string pNombre)
        {
            this._comando.Parameters.AddWithValue(pNombre, DBNull.Value);
        }

        public override SqlParameter AgregarParametroRetorno(string pNombre)
        {
            SqlParameter par = new SqlParameter(pNombre, SqlDbType.Int);
            par.Direction = ParameterDirection.ReturnValue;

            this._comando.Parameters.Add(par);

            return par;
        }
        #endregion
    }
}
